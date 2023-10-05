using System;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform ball;
    public Transform defensePoint;

    public float attackSpeed = 10;
    public float defenseSpeed = 5;
    float speed = 10;

    private Vector3 targetPosition;
    
    private void Update()
    {
        bool ballInRange = ball.position.x > 0;

        if (ballInRange)
        {
            // attack
            targetPosition = ball.position;
            speed = attackSpeed;
        }
        else
        {
            // defense 
            targetPosition = defensePoint.position;
            speed = defenseSpeed;
        }
        
        var finalPosition = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        GetComponent<Rigidbody2D>().MovePosition(finalPosition);
    }
}
