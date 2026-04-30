using UnityEngine;

public class Balloon : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    
    void Update()
    {
        // Get horizontal input
        float horizontalInput = 0;
        
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1;
        }
        
        // Move balloon horizontally
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);
    }
}
