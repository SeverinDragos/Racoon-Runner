using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PerkCountdown : MonoBehaviour
{
    private float currentTime = 0f;

    private float startingTime = 10f;

    [SerializeField] private TextMeshPro countDownText;
    
    // Start is called before the first frame update
    void Start()
    {
        // this.gameObject.active = false;
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = currentTime.ToString("0");

        if (currentTime <= 3)
            countDownText.color = Color.red;

        if (currentTime <= 0)
        {
            currentTime = 0;
            this.gameObject.active = false;
        }
    }
}
