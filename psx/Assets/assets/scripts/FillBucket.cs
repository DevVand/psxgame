using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillBucket : MonoBehaviour
{
    public GameObject parent;
    public UseDelegator usescript;
    public Bucket bucket;
    public Pickup pickup;

    void Start()
    {
        usescript = GetComponent<UseDelegator>();
        usescript.use = Water;
    }

    public void Water()
    {
        for (int i = 0; i <= 1; i++)
        {
            if (pickup.carrying[i] && pickup.carriedObject[i].GetComponent<Bucket>() != null)
            {
                if (!bucket.isFull)
                    bucket.PutWater();
            }
        }
    }

    public void NoWater()
    {
        if (bucket.isFull)
        {
            bucket.UnputWater();
        }
    }
 }
