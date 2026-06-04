using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    
    void OnTriggerEnter (Collider other)
    {
        if (other.name == "Player")
            Debug.Log ("Player Detected: Attack!");
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
            Debug.Log("Player out of Range - Resume Patrol");
    }
}
