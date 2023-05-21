using UnityEngine;


public class Element : MonoBehaviour
{
    public Player  player;
    public Spawner spawner;
    public bool    moving = true;


    public void Switch()
    {
        var spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.color = spriteRenderer.color == Color.white ? Color.black : Color.white;
    }


    private void Start()
    {
        this.transform.Translate(0, this.transform.localScale.y / 2, 0);
    }


    void Update()
    {
        if (this.moving) this.transform.Translate(this.player.speed * -Time.deltaTime, 0, 0);
        if (!(this.transform.position.x < -40)) return;
        Destroy(this.gameObject);
    }
}
