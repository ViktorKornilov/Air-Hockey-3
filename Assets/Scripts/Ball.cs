using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public TMP_Text playerScoreText;
    public TMP_Text enemyScoreText;
    
    public int playerScore = 0;
    public int enemyScore = 0;

    public AudioClip hitSound;
    public AudioClip goalSound;
    AudioSource source;

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
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        source.clip = hitSound;
        source.Play();
        
        if (other.gameObject.name.Contains("Goal"))
        {
            transform.position = Vector3.zero;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            
            source.clip = goalSound;
            source.Play();
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
