using UnityEngine;

public class Player : MonoBehaviour
{
    private void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        
        if (mousePos.x > 0) mousePos.x = 0; // clamp player x position
        
        GetComponent<Rigidbody2D>().MovePosition(mousePos);
    }
}
