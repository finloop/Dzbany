using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {
	public int playerSpeed = 10;
	public static bool facingRight = true;
	public int playerJumpForce = 1250;
	public float moveX;
    public bool isGrounded;
    public int maxSpeedHorizontal;
    public int maxSpeedVertical;
    public bool canDoubleJump;

    // Update is called once per frame
    void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit != null && hit.collider != null && hit.distance <= 0.9f && hit.collider.tag.Equals("Ground"))
        {
            isGrounded = true;
        }
        else
            isGrounded = false;

        PlayerMove();
    }

	void PlayerMove() {
        //CONTROLS
        if (!GlobalVariables.isPaused) {
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetAxis("Vertical")<0)
            Jump();
        //animation+
        //player direction
        //phisics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        }
    }

	void Jump() {
       
     if(isGrounded || canDoubleJump)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * playerJumpForce;
            canDoubleJump = false;
        }

        // jumping coded
        
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Electro"))
        {
            gameObject.GetComponent<Player_Health>().TakeDamage(50);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Electro"))
        {
            gameObject.GetComponent<Player_Health>().TakeDamage(50);
        }
    }

}
