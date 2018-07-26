using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTrigger : MonoBehaviour {
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag.Equals("SceneTrigger"))
        {
            string sceneName = collision.collider.gameObject.GetComponent<SceneTrigger>().sceneName;
            SceneManager.LoadScene(sceneName);
        }
    }
}
