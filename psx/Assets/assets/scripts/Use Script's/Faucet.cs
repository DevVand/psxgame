using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faucet : MonoBehaviour
{
    public Pickup pickup;
    public UseDelegator usescript;

    private void Start()
    {
        usescript = GetComponent<UseDelegator>();

        usescript.use = EncherComAgua;
    }

    public void EncherComAgua()
    {
        for (int i = 0; i <= 1; i++)
        {
            if (pickup.carrying[i] && pickup.carriedObject[i].GetComponent<Bucket>() != null)
            {
                pickup.carriedObject[i].GetComponent<Bucket>().EncheBalde();
            }
        }
    }

}
