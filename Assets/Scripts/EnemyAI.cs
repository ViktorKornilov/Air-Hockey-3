using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    public Transform ball;
    public Transform defensePoint;

    public float attackSpeed = 10;
    public float defenseSpeed = 5;
    float speed = 10;

    private Vector3 targetPosition;
    private Vector3 defensePointOffset;

    public float moveCooldown;
    
    private void Update()
    {
        moveCooldown -= Time.deltaTime;
        if (moveCooldown <= 0)
        {
            defensePointOffset = new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f));
            moveCooldown = 2;
        }
        
        bool ballInRange = ball.position.x > 0;

        if (ballInRange)
        {
            // attack
            targetPosition = ball.position + defensePointOffset/5f;
            if (targetPosition.x > defensePoint.position.x + 0.8f) targetPosition.x = defensePoint.position.x + 0.8f;
            speed = attackSpeed;
        }
        else
        {
            // defense 
            targetPosition = defensePoint.position;
            targetPosition += defensePointOffset;
            speed = defenseSpeed;
        }
        
        var finalPosition = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        GetComponent<Rigidbody2D>().MovePosition(finalPosition);
    }
}
