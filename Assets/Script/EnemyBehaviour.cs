using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    private NavMeshAgent _agent;
    public Transform PatrolRoute;
    private List<Transform> _locations = new List<Transform>();
    private int _locationIndex = 0;
    private Transform _player;

    private GameBehaviour _gameManager;
    private int _enemyLives = 3;
    
    public int EnemyLives
    {
        get { return _enemyLives; }
        set
        {
            _enemyLives = value;
            if (_enemyLives <= 0) Destroy(this.gameObject);
        }
    }

    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameBehaviour>();
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.Find("Player").transform;
        if (PatrolRoute != null)
        {
            foreach (Transform child in PatrolRoute)
            {
                _locations.Add(child);
            }
        }
        if (_locations.Count > 0)
        {
            
        }
    }

    void Update()
    {
        if (_locations.Count > 0 && _agent.remainingDistance < 0.5f && !_agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

    void MoveToNextPatrolLocation()
    {
        if (_locations.Count == 0) return;
        _agent.destination = _locations[_locationIndex].position;
        _locationIndex = (_locationIndex + 1) % _locations.Count;

    }

    void OnTriggerEnter (Collider other)
    {
        if (other.name == "Player")
        {
            if (_gameManager != null) _gameManager.HP -= 2;

            if (_agent != null && _player != null) _agent.destination = _player.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            EnemyLives -= 1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            if (_locations.Count > 0) MoveToNextPatrolLocation();
        }
    }
}
