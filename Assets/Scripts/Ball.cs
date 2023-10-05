using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public TMP_Text playerScoreText;
    public TMP_Text enemyScoreText;
    
    public int playerScore = 0;
    public int enemyScore = 0;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Contains("Goal"))
        {
            transform.position = Vector3.zero;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if (other.gameObject.name.Contains("Enemy Goal"))
        {
            playerScore++;
            playerScoreText.text = playerScore.ToString();
        }
        
        if (other.gameObject.name.Contains("Player Goal"))
        {
            enemyScore++;
            enemyScoreText.text = enemyScore.ToString();
        }
    }
}
