using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : MonoBehaviour {
    private float currentTime = 0f;
    private float animationTime = 2f;
    private bool isInvisible = false;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isInvisible)
            currentTime += Time.deltaTime;
        if (currentTime >= animationTime)
        {
            isInvisible = false;
            currentTime = 0f;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player") && !isInvisible)
        {
            collision.gameObject.GetComponent<Player_Movement>().canDoubleJump = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            isInvisible = true;
        }

    }
}
