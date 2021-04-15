using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillBucket : MonoBehaviour
{
    public GameObject parent;
    public UseDelegator usescript;
    public bool visible = false;
    public bool isFull = false;

    void Start()
    {
        usescript = GetComponent<UseDelegator>();
        if (!visible && !isFull)
        {
            usescript.use = Water;
        } else
        {
            usescript.use = NoWater;
        }
    }

    public void Water()
    {
        Debug.Log("Disney?");
        parent.transform.GetChild(0).gameObject.SetActive(true);
        isFull = true;
    }

    public void NoWater()
    {
        parent.transform.GetChild(0).gameObject.SetActive(false);
        isFull = false;
    }
 }
