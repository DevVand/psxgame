using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clean : MonoBehaviour
{
    public Bucket bucket;
    public GameObject parent;
    public UseDelegator usescript;
    
    void Start()
    {
        usescript = GetComponent<UseDelegator>();
        usescript.use = CleanDirty;
    }

    public void CleanDirty()
    {
        if(bucket.isFull)
        {
            bucket.UnputWater();
            Destroy(gameObject);
            bucket.isFull = false;
        }
    }
 }
