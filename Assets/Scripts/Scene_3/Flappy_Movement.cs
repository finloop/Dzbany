using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flappy_Movement : MonoBehaviour {
	public static int playerSpeed = 4;
	public static int playerJumpForce = 5;
	public float moveX;
    public bool isGrounded;
    public int maxSpeedHorizontal;
    public int maxSpeedVertical;
    public static bool flappyMode = true;

    // Update is called once per frame
    void Update () {
        PlayerMove();
    }

	void PlayerMove() {
        //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetAxis("Vertical")<0)
            Jump();
        //animation
        //player direction
        //phisics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);


    }

	void Jump() {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if ( (hit != null && hit.collider != null && hit.distance < 1.27f && hit.collider.tag.Equals("Ground")) || flappyMode)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * playerJumpForce;
        }
        // jumping coded
        

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Electro")) {
            gameObject.GetComponent<Player_Health>().TakeDamage(50);
        }
    }
}
