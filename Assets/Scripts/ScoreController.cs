using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public int score = 0;
    private TMPro.TMP_Text text;
    public TMPro.TMP_Text highscore;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TMP_Text>();
        text.SetText("Score: " + score.ToString());
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    public void UpdateScore(int amount) {
        score += amount;
        text.SetText("Score: " + score.ToString());
        if (score > PlayerPrefs.GetInt("Highscore", 0)) {
            PlayerPrefs.SetInt("Highscore", score);
            highscore.text = "Highscore: " + score.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
