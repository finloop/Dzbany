using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flappy_Movement : MonoBehaviour {
	public int playerSpeed = 10;
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
        //phisics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);


    }

	void Jump() {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * playerJumpForce;
        // jumping coded
        

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Electro")) {
            SceneManager.LoadScene("Scenes/youdied");
        }
    }
}
