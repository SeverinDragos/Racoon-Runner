using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCollider : MonoBehaviour
{
    private string gameOverScene = "GameOver";

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            // Save the current score
            int scoreValue = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>().score;
            PlayerPrefs.SetInt("Score", scoreValue);
            // load new scene
            SceneManager.LoadScene(gameOverScene);

            AudioManager.instance.StopPlaying("InGameMusic");
            AudioManager.instance.Play("Obstacle");
            AudioManager.instance.Play("GameOver");
        }
    }
}