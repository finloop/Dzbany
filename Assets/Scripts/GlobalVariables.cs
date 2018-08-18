using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GlobalVariables : MonoBehaviour {
    public static bool isPaused = false;
    public static bool isDialogueHappening = false;
    public static string lastScene = "Scenes/1";
    public static int player_health;
    public static List<KeyValuePair<string, Vector3>> scenes_positions = new List<KeyValuePair<string, Vector3>>();
    public static bool cheatMode = false;
    public void LoadLastScene()
    {
        SceneManager.LoadScene(lastScene);
    }

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
        if(!scene.name.Equals("youdied"))
        {
            lastScene = "Scenes/" + scene.name;
            isPaused = false;
            isDialogueHappening = false;
            
        }
    }

}
