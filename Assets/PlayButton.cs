using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("Level");
    }
}
