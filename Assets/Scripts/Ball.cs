
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Ball : MonoBehaviour
{
    public TMP_Text playerScoreText;
    public TMP_Text enemyScoreText;
    
    public int playerScore = 0;
    public int enemyScore = 0;

    public AudioClip hitSound;
    public AudioClip goalSound;
    AudioSource source;

    public bool shouldRespawn;
    public Transform deathPoint;
    float respawnTimer;
    Vector3 respawnPosition;
    
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // teleport ball back if it glitches out of the level
        var distanceToCenter = Vector3.Distance(Vector3.zero, transform.position);
        if (distanceToCenter > 10)
        {
            transform.position = Vector3.zero;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            print("ball teleported back to level!");
        }

        // if goal, after 2 seconds teleport ball back
        if (shouldRespawn)
        {
            respawnTimer += Time.deltaTime;
            if (respawnTimer >= 2)
            {
                transform.position = respawnPosition;
                respawnTimer = 0;
                shouldRespawn = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        source.clip = hitSound;
        source.Play();
        
        
        if (other.gameObject.name.Contains("Enemy Goal"))
        {
            playerScore++;
            playerScoreText.text = playerScore.ToString();
            respawnPosition = Vector3.right;
        }
        
        if (other.gameObject.name.Contains("Player Goal"))
        {
            enemyScore++;
            enemyScoreText.text = enemyScore.ToString();
            respawnPosition = Vector3.left;
        }
        
        
        if (other.gameObject.name.Contains("Goal"))
        {
            if (playerScore >= 7 || enemyScore >= 7)
            {
                SceneManager.LoadScene("Menu");
            }
            
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            
            source.clip = goalSound;
            source.Play();

            shouldRespawn = true;
            transform.position = deathPoint.position;
            
        }

    }
}
