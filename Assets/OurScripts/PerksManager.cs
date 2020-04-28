using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PerksManager : MonoBehaviour
{
    public static PerksManager instance;

    [SerializeField]
    private TextMeshPro countDownText;

    void Awake() 
    {
        if (instance == null) 
            instance = this;
        else
            Destroy(gameObject);
    }

    public void ActivateScoreMultiplierPerk() 
    {
        StartCoroutine(ScoreMultiplier());
    }

    public void ActivateInvinciblePerk() 
    {
        StartCoroutine(Invincible());
    }

    IEnumerator ScoreMultiplier() 
    {
        GameObject[] stars;
        float timePassed = 0f;
        while (timePassed < 5) 
        {
            if(!countDownText.text.Contains("2x Score!\n")) 
            {
                countDownText.text += "2x Score!\n";
            }
            stars = GameObject.FindGameObjectsWithTag("Reward");
            foreach (GameObject s in stars)
            {
                RewardController controller = s.GetComponent<RewardController>();
                controller.isStarPerkActive = true;
            }

            timePassed += Time.deltaTime;
            yield return null;
        }
        countDownText.text = countDownText.text.Replace("2x Score!\n", "");
        stars = GameObject.FindGameObjectsWithTag("Reward");
        foreach (GameObject s in stars)
        {
            RewardController controller = s.GetComponent<RewardController>();
            controller.isStarPerkActive = false;
        }
    }

    IEnumerator Invincible() 
    {
        GameObject[] stars;
        float timePassed = 0f;
        while (timePassed < 5) 
        {
            if(!countDownText.text.Contains("Invincible!\n")) 
            {
                countDownText.text += "Invincible!\n";
            }
            stars = GameObject.FindGameObjectsWithTag("Obstacle");
            foreach (GameObject s in stars)
            {
                ObstacleCollider controller = s.GetComponent<ObstacleCollider>();
                controller.isInvinciblePerkActive = true;
            }

            timePassed += Time.deltaTime;
            yield return null;
        }
        countDownText.text = countDownText.text.Replace("Invincible!\n", "");
        stars = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject s in stars)
        {
            ObstacleCollider controller = s.GetComponent<ObstacleCollider>();
            controller.isInvinciblePerkActive = false;
        }
    }
}
