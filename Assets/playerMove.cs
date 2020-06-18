using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float horizontalSpeed;
    private float verticalSpeed = 300f;
    float speed = 2;
    
    public GameObject player;
    Rigidbody2D fizik;
    
    public bool facingRight = true;
    public bool isGrounded = true;
    void Start()
    {
        fizik = player.GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        horizontalSpeed = Input.GetAxisRaw("Horizontal") * speed;
        
        
        if (fizik.velocity.x > 0.5f && !facingRight )
        {
            
            Flip();
        }
        else if (fizik.velocity.x < -0.5f && facingRight)
        {
            
            Flip();
        }

        if(Input.GetAxisRaw("Vertical") == 1 && isGrounded)
        {
            fizik.AddForce(new Vector2(0f, verticalSpeed));
            isGrounded = false;
        }

         
        

    }

    private void FixedUpdate()
    {
        
            fizik.velocity = new Vector2(horizontalSpeed, fizik.velocity.y);
        
        
    }

    private void Flip()
    {

        facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }
}
