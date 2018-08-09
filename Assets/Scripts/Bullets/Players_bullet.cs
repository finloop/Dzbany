using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players_bullet : MonoBehaviour {

	public float bulletSpeed = 100000f;
	public string destroyOnCollisionTag = "Enemy";
	public bool addedForce = false;

	// Use this for initialization
	void Awake() {
		gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
	}
	void Start () {
		gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * bulletSpeed);
	}
	
	// Update is called once per frame
	void Update () {
      
	}

	private void OnCollisionEnter2D(Collision2D collision)
    {
		if(collision.gameObject.tag.Equals(destroyOnCollisionTag)) {
			collision.gameObject.GetComponent<Player_Health>().TakeDamage(34);
			Destroy(gameObject);
		} else if(collision.gameObject.tag.Equals("Electro") || collision.gameObject.tag.Equals("Ground") || collision.gameObject.tag.Equals("NoDamage")) {
			Destroy(gameObject);
		}else if (collision.gameObject.tag.Equals("Boss")) {
			collision.gameObject.GetComponent<Enemy_Base>().health -= 20;
			Destroy(gameObject);
		}
	}
}
