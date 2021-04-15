using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clean : MonoBehaviour
{
    [HideInInspector]
    public FillBucket bucket;
    public GameObject parent;
    public UseDelegator usescript;

    void Start()
    {
        bucket = GetComponent<FillBucket>();
        usescript = GetComponent<UseDelegator>();
        usescript.use = CleanDirty;
    }

    public void CleanDirty()
    {   

        Debug.Log("Chegou");
        bucket.NoWater();
        Destroy(gameObject);
    }
 }
