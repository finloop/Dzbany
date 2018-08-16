using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_ai : MonoBehaviour {
    public int enemySpeed;
    public int xMoveDirection;

	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMoveDirection, 0));
        RaycastHit2D ahit = Physics2D.Raycast(transform.position, new Vector2(-xMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * enemySpeed;

        float hitDistance = 0.1f;
        float ahitDistance = 0.7f;
        if (xMoveDirection > 0)
        {
            hitDistance = 0.7f;
            ahitDistance = 0.1f;
        }

        else
        {
            hitDistance = 0.1f;
            ahitDistance = 0.7f;
        }
           

        if (ahit != null && ahit.collider != null && hit != null && hit.collider != null && (hit.distance <= hitDistance || ahit.distance <= ahitDistance))
        {
            
            Debug.Log(hitDistance);
            Debug.Log(ahitDistance);
            Debug.Log(hit.distance);
            Debug.Log(ahit.distance);
            if (hit.collider.gameObject.tag.Equals("Player"))
            {
                Destroy(hit.collider.gameObject);
                SceneManager.LoadScene("Temp");
            } else if (ahit.collider.gameObject.tag.Equals("Player"))
            {
                Destroy(ahit.collider.gameObject);
                SceneManager.LoadScene("Temp");
            }
            FlipEnemy();

        }

        Vector2 pos = transform.position;
        if(xMoveDirection > 0)
        {
            pos.x += xMoveDirection;
            RaycastHit2D hitdown = Physics2D.Raycast(pos, Vector2.down);
            if (hitdown.distance >= 0.7)
                FlipEnemy();
        } else
        {
            pos.x += -0.2f;
            RaycastHit2D hitdown = Physics2D.Raycast(pos, Vector2.down);
            if (hitdown.distance >= 0.7)
                FlipEnemy();
        }




    }

    void FlipEnemy()
    {
        if(xMoveDirection > 0)
        {
            xMoveDirection = -1;
        } else
        {
            xMoveDirection = 1;
        }
    }
}
