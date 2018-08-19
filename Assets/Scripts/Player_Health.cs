using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    public static float health = 100;


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
        if(gameObject.tag.Equals("Player"))
        {
            health -= damage;
            gameObject.tag = "NoDamage";
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            GameObject healthBar = GameObject.Find("Canvas/Mask/Health");
            healthBar.GetComponent<Image>().fillAmount = 1f - (health / 100f);
            StartCoroutine(SetTag(gameObject));
        }

    }

    public void RestoreHealth()
    {
        if (gameObject.tag.Equals("Player"))
        {
            health = 100;
            gameObject.tag = "NoDamage";
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            GameObject healthBar = GameObject.Find("Canvas/Mask/Health");
            healthBar.GetComponent<Image>().fillAmount = 1f - (health / 100f);
            StartCoroutine(SetTag(gameObject));
        }

    }

    IEnumerator SetTag(GameObject gameObject)
    {
        yield return new WaitForSecondsRealtime(0.4f);
        gameObject.tag = "Player";
		gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
