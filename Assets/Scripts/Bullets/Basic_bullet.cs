using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_bullet : MonoBehaviour {
	public float bulletSpeed = 100f;
	public string destroyOnCollisionTag = "Player";
	public bool addedForce = false;
    public int damage;

	// Use this for initialization
	void Awake() {
		gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
	}
	void Start () {
		gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * bulletSpeed);
	}
	
	// Update is called once per frame
	void Update () {
      transform.RotateAroundLocal(Vector2.up, 5f * Time.deltaTime);
	}

	private void OnCollisionEnter2D(Collision2D collision)
    {
		if(collision.gameObject.tag.Equals(destroyOnCollisionTag)) {
			collision.gameObject.GetComponent<Player_Health>().TakeDamage(damage);
			Destroy(gameObject);
		} else if(collision.gameObject.tag.Equals("Electro") || collision.gameObject.tag.Equals("Ground") || collision.gameObject.tag.Equals("NoDamage")) {
			Destroy(gameObject);
		}
	}
}
