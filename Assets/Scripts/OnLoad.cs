using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnLoad : MonoBehaviour
{
    public Transform position;
    public AudioSource audioSource;
    public AudioClip audioClip;

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if ((gameObject.GetComponent<AudioSource>() != null) && (audioClip != null))
        {
            audioSource.clip = audioClip;
            audioSource.loop = true;
            audioSource.Play();
        }
        if (!scene.name.Equals("youdied"))
        {
            if (GlobalVariables.scenes_positions != null)
                foreach (KeyValuePair<string, Vector3> kvp in GlobalVariables.scenes_positions)
                {
                    if (kvp.Key.Equals(scene.name))
                    {
                        position.position = kvp.Value;
                        return;
                    }
                }
        }

        StartCoroutine(start());

    }

    IEnumerator start()
    {
        yield return new WaitForSecondsRealtime(1);
        GetComponent<DialogueTrigger>().TriggerDialogue();
    }

}
