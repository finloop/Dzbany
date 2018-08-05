using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flappy_Movement : MonoBehaviour {
	public int playerSpeed = 10;
	public static bool facingRight = true;
	public int playerJumpForce = 1250;
	public float moveX;
    public bool isGrounded;
    public int maxSpeedHorizontal;
    public int maxSpeedVertical;

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
        if (moveX > 0.0f && !facingRight)
            FlipPlayer();
        else if (moveX < 0.0f && facingRight)
            FlipPlayer();
        //phisics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);


    }

	void Jump() {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * playerJumpForce;
        // jumping coded
        

	}

    void FlipPlayer()
    {
        if(facingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            transform.position = new Vector3(transform.position.x + 0.7f, transform.position.y, transform.position.z);
        } else if (!facingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.position = new Vector3(transform.position.x - 0.7f, transform.position.y, transform.position.z);
        }
        facingRight = !facingRight;
    }
}
