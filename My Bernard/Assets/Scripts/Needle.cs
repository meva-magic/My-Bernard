using UnityEngine;

public class Needle : MonoBehaviour
{
    [Header("Movement Settings")]
    public float fallSpeed = 3f;
    
    void Update()
    {
        // Move needle down
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        
        // Destroy if off screen (below screen)
        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Balloon"))
        {
            // Hit balloon - collection
            AudioManager.instance.Play("Ball");
            GameManager.instance.CollectNeedle();
            Destroy(gameObject);
        }
        else if (other.CompareTag("Target"))
        {
            // Hit floor/target - miss
            AudioManager.instance.Play("Scream");
            GameManager.instance.MissNeedle();
            Destroy(gameObject);
        }
    }
}
