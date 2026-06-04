using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float OnScreenDelay = 3f;
    void Start()
    {
        Destroy(this.gameObject, OnScreenDelay);
    }
}
