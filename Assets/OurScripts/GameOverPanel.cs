using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public Button restartButton;

    public Button menuButton;
    
    private string gameScene = "SampleScene";

    private string menuScene = "Menu";
    private void Awake()
    {
        int scoreValue = PlayerPrefs.GetInt("Score");
        int highScoreValue = PlayerPrefs.GetInt("Highscore");

        scoreText.text = "Current score: " + scoreValue;
        highScoreText.text = "Highest score:" + highScoreValue;

        restartButton.onClick.AddListener(delegate () { RestartGame(); });
        
        menuButton.onClick.AddListener(delegate () { GoToMenu(); });
    }

    private void RestartGame()
    {
        // Reset score
        PlayerPrefs.SetInt("Score", 0);
        // load new scene
        SceneManager.LoadScene(gameScene);
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            AudioManager.instance.StopPlaying("GameOver");
            AudioManager.instance.Play("InGameMusic");
        }
    }

    private void GoToMenu()
    {
        // Reset score
        PlayerPrefs.SetInt("Score", 0);
        // load new scene
        SceneManager.LoadScene(menuScene);
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            AudioManager.instance.StopPlaying("GameOver");
            AudioManager.instance.Play("Menu");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
