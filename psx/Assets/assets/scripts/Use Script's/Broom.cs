using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour
{
    public int cleanFactor = 6;
    public int cleaness;

    public Pickup pickup;
    public GameObject parentVassoura;
    public UseDelegator usescript;

    
    private void Start()
    {
        cleaness = cleanFactor;
        usescript = GetComponent<UseDelegator>();
        usescript.use = Vassoura;
    }

    public void Vassoura()
    {
        for (int i = 0; i <= 1; i++)
        {
            if (pickup.carrying[i] && pickup.carriedObject[i].GetComponent<Bucket>() != null)
            {
                pickup.carriedObject[i].GetComponent<Bucket>().EsvaziaBalde();
                LimpaVassoura();
            }
        }
    }

    public void LimpaVassoura() {
        cleaness = cleanFactor;
        parentVassoura.transform.GetChild(0).gameObject.SetActive(false);
    }
    public void SujaVassoura() {
        if (cleaness <= 0)
            parentVassoura.transform.GetChild(0).gameObject.SetActive(true);
        else
            cleaness -= 1;
        }
    public bool isClean() { return cleaness > 0; }
}
