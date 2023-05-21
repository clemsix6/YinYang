using UnityEngine;
using UnityEngine.SceneManagement;


public class Obstacle : MonoBehaviour
{
    public Element element;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == this.element.player.gameObject)
            SceneManager.LoadScene("Scenes/Menu");
    }
}
