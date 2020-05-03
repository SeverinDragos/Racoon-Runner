using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEnablerer : MonoBehaviour
{
    public GameObject[] tileBits;

    private void ActivateBits()
    {
        foreach(GameObject go in tileBits)
        {
            go.SetActive(true);
        }
    }

    public void Enable()
    {
        ActivateBits();
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
