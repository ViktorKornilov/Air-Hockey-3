using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Contains("Goal"))
        {
            transform.position = Vector3.zero;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if (other.gameObject.name.Contains("Enemy Goal"))
        {
            // score++
        }
    }
    
    // Detect if ball collides with player/enemy goal
    // increase score for player/enemy
    // show score using TextMeshPro
    // create webGL build
    // publish github.com repo and create readme.md file with webgl build link
    // copy link to discord
    
}
