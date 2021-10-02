using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirty : MonoBehaviour
{
    [SerializeField] int stage;

    [SerializeField] GameObject prefab;

    private Pickup pickup;
    private Menu menu;
    public UseDelegator usescript;

    private void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
        pickup = GameObject.FindGameObjectWithTag("Player").GetComponent<Pickup>();
        usescript = GetComponent<UseDelegator>();
        usescript.use = ExcluiSujeira;
    }

    public void ExcluiSujeira()
    {
        for (int i = 0; i <= 2; i++)
        {
            if (i == 2) {
                menu.message("noMop");
                break;
            }
            if (pickup.carrying[i] && pickup.carriedObject[i].GetComponent<Broom>() != null)
            {
                Broom broom = pickup.carriedObject[i].GetComponent<Broom>();

                if (broom.isClean())
                {
                    broom.SujaVassoura();
                    broom.playAudio();
                    broom.swash(i);
                    if (stage == 1)
                    {
                        menu.dirtDone();
                        Destroy(gameObject);
                    }
                    else
                    {
                        Quaternion tr = transform.rotation;
                        GameObject obj = Instantiate(prefab, transform.position, Quaternion.Euler(tr.x - 90, tr.y + Random.Range(0, 360), tr.z));
                        obj.transform.localScale = transform.localScale;
                        Destroy(gameObject);
                    }
                } else {
                    menu.message("dryMop");
                }
                break;
            }

        }

    }
}
