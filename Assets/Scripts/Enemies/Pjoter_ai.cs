using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pjoter_ai : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    { 

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 player_position = collision.collider.transform.position;

        
        Vector2 player_size = collision.collider.GetComponent<BoxCollider2D>().size * collision.collider.gameObject.transform.localScale;
        

        player_position.y -= player_size.y/2 - 0.1f;

        Vector2 enemy_position = transform.position;

        Vector2 enemy_size = gameObject.GetComponent<BoxCollider2D>().size * gameObject.transform.localScale;

        enemy_position.y += enemy_size.y/2;


        if (player_position.y >= enemy_position.y)
        {
            Destroy(gameObject);
            collision.collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.collider.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500);
        } else
        {
            if(collision.collider.tag.Equals("Player")) {
                collision.gameObject.GetComponent<Player_Health>().TakeDamage(34);
            }
                
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
         Vector2 player_position = collision.collider.transform.position;

        
        Vector2 player_size = collision.collider.GetComponent<BoxCollider2D>().size * collision.collider.gameObject.transform.localScale;
        

        player_position.y -= player_size.y/2 - 0.1f;

        Vector2 enemy_position = transform.position;

        Vector2 enemy_size = gameObject.GetComponent<BoxCollider2D>().size * gameObject.transform.localScale;

        enemy_position.y += enemy_size.y/2;


        if (player_position.y >= enemy_position.y)
        {
            Destroy(gameObject);
            collision.collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.collider.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500);
        } else
        {
            if(collision.collider.tag.Equals("Player")) {
                collision.gameObject.GetComponent<Player_Health>().TakeDamage(34);
            }
                
        }
    }

}
