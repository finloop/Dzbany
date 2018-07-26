using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour {
    private float timeLeft = 120;
    private int score = 0;
    public GameObject timeLeftUI;
    public GameObject scoreUI;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = "Time left: " + (int)timeLeft;
        scoreUI.gameObject.GetComponent<Text>().text = "Score: " + (int)score;
        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene("Temp");
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("EndGame"))
        CountScore();
        if (collision.gameObject.name.Equals("Dzban"))
        {
            score += 100;
            Destroy(collision.gameObject);
        }

    }

    void CountScore()
    {
        score += (int) timeLeft * 10;
    }
}
