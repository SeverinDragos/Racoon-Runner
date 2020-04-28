using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardController : MonoBehaviour
{
    Renderer Renderer;
    Transform rotator;
    public int rewardValue = 20;
    public float rotateSpeed = 100f;
    public ScoreController scoreController;
    public bool isStarPerkActive = false;

    // Start is called before the first frame update
    void Start()
    {
        rotator = GetComponentInChildren<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (PlayerPrefs.GetInt("sound") == 1)
            AudioManager.instance.Play("Reward");
        scoreController = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>();
        if (isStarPerkActive)
            scoreController.UpdateScore(rewardValue * 2);
        else
            scoreController.UpdateScore(rewardValue);
        this.gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotator.transform.Rotate(new Vector3(1,1,0) * rotateSpeed * Time.deltaTime);
    }
}
