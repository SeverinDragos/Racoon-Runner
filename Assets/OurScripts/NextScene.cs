using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextScene : MonoBehaviour
{
    private Button go;

    public String nextScene;
    // Start is called before the first frame update
    void Start()
    {
        go = GetComponent<Button>();
        go.onClick.AddListener(GoToNextScene);
    }

    void GoToNextScene()
    {
        // set previous scene
        PlayerPrefs.SetString("previousScene", SceneManager.GetActiveScene().name);
        // load new scene
        SceneManager.LoadScene(nextScene);
        
        AudioManager.instance.StopPlaying("Menu");
        AudioManager.instance.Play("InGameMusic");
    }

}