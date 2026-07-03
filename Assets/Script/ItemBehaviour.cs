using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public GameBehaviour GameManager;
    void Start()
    {
        GameManager = GameObject.Find("Game Manager").GetComponent<GameBehaviour>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision from: {collision.collider.name} - Frame: {Time.frameCount}");
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.gameObject);
            Debug.Log("Item Collected");
            Debug.Log(collision.collider.name);
            if (GameManager != null) GameManager.Items += 1;
        }
    }
}
