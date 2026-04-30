using UnityEngine;

public class Target : MonoBehaviour
{
    // Floor that catches missed needles
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Needle"))
        {
        }
    }
}