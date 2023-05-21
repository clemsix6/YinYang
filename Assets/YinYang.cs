using UnityEngine;

public class YinYang : MonoBehaviour
{
    public Element element;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == this.element.player.gameObject) {
            this.element.spawner.Switch();
            this.element.spawner.Point();
            Destroy(this.gameObject);
        }
    }
}
