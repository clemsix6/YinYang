using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float       speed;
    public float       floor;
    public float       jumpForce;
    public Rigidbody2D rigidbody2D;
    
    private float positionX;
    private  int   jumpCount = 0;
    private float lastRefill = 0;


    private void Start()
    {
        this.lastRefill = Time.time;
    }


    void Roll()
    {
        this.transform.Rotate(0, 0, this.speed * (Mathf.PI * 8) * -Time.deltaTime);
        this.positionX = transform.position.x;
    }


    void StopFalling()
    {
        if (this.transform.position.y <= this.floor) {
            this.rigidbody2D.velocity = Vector2.zero;
            this.transform.position   = new Vector2(this.positionX, this.floor);
            if (this.lastRefill + 0.5f < Time.time) {
                this.lastRefill = Time.time;
                this.jumpCount  = 3;
            }
        }
    }


    void Jump()
    {
        if (this.jumpCount <= 0 || !Input.GetKeyDown(KeyCode.Space)) return;
        this.rigidbody2D.velocity = Vector2.zero;
        this.rigidbody2D.AddForce(new Vector2(0, jumpForce));
        this.jumpCount--;
        this.transform.position = new Vector2(this.positionX, this.transform.position.y);
    }


    void Update()
    {
        Roll();
        StopFalling();
        Jump();
    }
}
