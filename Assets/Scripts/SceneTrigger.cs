using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    public string sceneName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player"))
            SceneManager.LoadScene(sceneName);
    }

    public void StartScene()
    {

        SceneManager.LoadScene(sceneName);
    }
}
