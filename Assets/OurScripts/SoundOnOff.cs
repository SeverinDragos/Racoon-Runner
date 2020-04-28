using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOnOff : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle button;
    void Start()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
            button.isOn = true;
        if (button.isOn)
            PlayerPrefs.SetInt("sound",1);
        else 
            PlayerPrefs.SetInt("sound",0);
    }

    // Update is called once per frame
    void Update()
    {
        if (button.isOn)
            PlayerPrefs.SetInt("sound",1);
        else 
            PlayerPrefs.SetInt("sound",0);
        
    }
}
