using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkController : MonoBehaviour
{
    Renderer Renderer;
    Transform scalor;
    private float size = 0.5f;
    public float scaleSpeed = 0.5f;
    public float minScale = 0.5f;
    public float maxScale = 1.5f;
    public bool isScoreMultiplierPerk = false;
    public bool isInvinciblePerk = false;
    

    // Start is called before the first frame update
    void Start()
    {
        scalor = GetComponentInChildren<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isInvinciblePerk) 
        {
            PerksManager.instance.ActivateInvinciblePerk();    
        }
        if (isScoreMultiplierPerk) 
        {
            PerksManager.instance.ActivateScoreMultiplierPerk();    
        }
        // other.GetComponent<CapsuleController>().PowerUp();
        this.gameObject.SetActive(false);
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(size) > maxScale || Mathf.Abs(size) < minScale) 
            scaleSpeed *= -1;
        size += scaleSpeed * Time.deltaTime;
        scalor.transform.localScale = Vector3.one * size;
    }
}
