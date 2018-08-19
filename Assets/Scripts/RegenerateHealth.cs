using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerateHealth : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Player") && collision.gameObject.GetComponent<Player_Health>()!=null)
        {
            collision.gameObject.GetComponent<Player_Health>().RestoreHealth();
            Destroy(gameObject);
        }
       
    }
}
