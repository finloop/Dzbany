using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_terrain : MonoBehaviour {
    private float currentTime = 0f;
    private float animationTime = 2f;
    private bool isInvisible = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isInvisible)
            currentTime += Time.deltaTime;
        if(currentTime >= animationTime)
        {
            isInvisible = false;
            currentTime = 0f;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
        
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(doSomething(gameObject, collision));
        
    }

    IEnumerator doSomething(GameObject gameObject, Collision2D collision)
    {
        yield return new WaitForSecondsRealtime(0.5F);
        if (collision.gameObject.name.Equals("Player") && !isInvisible)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            isInvisible = true;
        }
    }
}
