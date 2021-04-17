using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public bool isFull = false;
    public GameObject parent;

    public void PutWater()
    {
        parent.transform.GetChild(0).gameObject.SetActive(true);
        isFull = true;    
    }
    public void UnputWater()
    {
        parent.transform.GetChild(0).gameObject.SetActive(false);
        isFull = false;
    }
}
