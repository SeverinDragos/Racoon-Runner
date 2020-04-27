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

    private string gameScene = "SampleScene";

    private void Awake()
    {
        int scoreValue = PlayerPrefs.GetInt("Score");
        int highScoreValue = PlayerPrefs.GetInt("Highscore");

        scoreText.text = "Current score: " + scoreValue;
        highScoreText.text = "Highest score:" + highScoreValue;

        restartButton.onClick.AddListener(delegate () { RestartGame(); });
    }

    private void RestartGame()
    {
        // Reset score
        PlayerPrefs.SetInt("Score", 0);
        // load new scene
        SceneManager.LoadScene(gameScene);
        AudioManager.instance.StopPlaying("GameOver");
        AudioManager.instance.Play("InGameMusic");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
