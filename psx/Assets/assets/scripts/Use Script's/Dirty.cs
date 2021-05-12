using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirty : MonoBehaviour
{
    [SerializeField] int stage;

    [SerializeField] GameObject prefab;
    private Pickup pickup;
    public UseDelegator usescript;

    private void Start()
    {
        pickup = GameObject.FindGameObjectWithTag("Player").GetComponent<Pickup>();
        usescript = GetComponent<UseDelegator>();
        usescript.use = ExcluiSujeira;
    }

    public void ExcluiSujeira()
    {
        for (int i = 0; i <= 1; i++)
        {
            if (pickup.carrying[i] && pickup.carriedObject[i].GetComponent<Broom>() != null)
            {
                if (pickup.carriedObject[i].GetComponent<Broom>().isClean())
                {
                    pickup.carriedObject[i].GetComponent<Broom>().SujaVassoura();
                    if (stage == 1)
                        Destroy(gameObject);
                    else
                    {
                        Quaternion tr = transform.rotation;
                        GameObject obj=Instantiate(prefab, transform.position, Quaternion.Euler(tr.x-90, tr.y + Random.Range(0, 360), tr.z));
                        obj.transform.localScale = transform.localScale;
                        Destroy(gameObject);
                    }
                }
            }
        }

    }
}
