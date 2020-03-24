using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReseterScript : MonoBehaviour
{

    public float resetDistance = 40;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Transform>().
        transform.parent.Translate(new Vector3(0, 0, -resetDistance));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
