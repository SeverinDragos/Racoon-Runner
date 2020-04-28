using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    public int active = 1;

    private bool started = false;
    void Awake() 
    {
        if (instance == null) 
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        active = PlayerPrefs.GetInt("sound");
        if (active == 1)
        {
            Play("Menu");
            started = true;
        }
    }

    public void Play(string name) 
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
        Debug.LogWarning("Sound: " + name + " not found!");
        return;
        }
        s.source.Play();
    }

    public void StopPlaying (string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
        Debug.LogWarning("Sound: " + name + " not found!");
        return;
        }
        s.source.Stop();
    }

    public void Update()
    {
        if (PlayerPrefs.GetInt("sound") == 0)
        {
            StopPlaying("Menu");
            started = false;
        }
        else
        { 
            if (!started)
            {
                Play("Menu");
                started = true;
            }
        }
    }
}
