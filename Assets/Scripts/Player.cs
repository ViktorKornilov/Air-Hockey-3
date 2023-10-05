using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 20;
    
    private void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        
        if (mousePos.x > 0) mousePos.x = 0; // clamp player x position

        var finalPosition = Vector3.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
        GetComponent<Rigidbody2D>().MovePosition(finalPosition);
    }
}
