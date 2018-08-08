using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    public static int health = 100;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -15)
        {
            SceneManager.LoadScene("Scenes/youdied");
        }
        if (health <= 0)
        {
            SceneManager.LoadScene("Scenes/youdied");
            health = 100;
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
        gameObject.tag = "NoDamage";
		gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(SetTag(gameObject));
    }

    IEnumerator SetTag(GameObject gameObject)
    {
        yield return new WaitForSecondsRealtime(0.3f);
        gameObject.tag = "Player";
		gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
