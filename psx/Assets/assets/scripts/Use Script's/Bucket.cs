using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public Pickup pickup;
    public GameObject parentBalde;
    public UseDelegator usescript;
    public bool isFull = false;

    private void Start()
    {
        usescript = GetComponent<UseDelegator>();
        usescript.use = LimpaVassoura;
    }

    public void EsvaziaBalde ()
    {
        parentBalde.transform.GetChild(0).gameObject.SetActive(false);
        isFull = false;
    }

    public void EncheBalde ()
    {
        parentBalde.transform.GetChild(0).gameObject.SetActive(true);
        isFull = true;
    }

    public void LimpaVassoura()
    {
        for (int i = 0; i <= 1; i++)
        {
            if (pickup.carrying[i] && pickup.carriedObject[i].GetComponent<Broom>() != null)
            {
                EsvaziaBalde();
                pickup.carriedObject[i].GetComponent<Broom>().LimpaVassoura();
            }
        }
    }
}
