using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCollider : MonoBehaviour
{
    private string gameOverScene = "End";

    public bool isInvinciblePerkActive = false;

    private void OnTriggerEnter(Collider col)
    {
        if(isInvinciblePerkActive) 
        {
            if (PlayerPrefs.GetInt("sound") == 1)
                AudioManager.instance.Play("Obstacle");
            ScoreController scoreController = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>();
            scoreController.UpdateScore(15);
            this.gameObject.SetActive(false);
        }
        else 
        {
            if (col.gameObject.tag == "Player")
            {
                // Save the current score
                int scoreValue = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>().score;
                PlayerPrefs.SetInt("Score", scoreValue);
                // load new scene
                SceneManager.LoadScene(gameOverScene);

                if (PlayerPrefs.GetInt("sound") == 1)
                {
                    AudioManager.instance.StopPlaying("InGameMusic");
                    AudioManager.instance.Play("Obstacle");
                    AudioManager.instance.Play("GameOver");
                }
            }
        }
    }
}