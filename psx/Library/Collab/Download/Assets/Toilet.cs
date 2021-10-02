using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : MonoBehaviour
{

    private Menu menu;
    public UseDelegator usescript;

    private void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
        usescript = GetComponent<UseDelegator>();
        usescript.use = flush;
    }

    public void flush() {
        menu.toiletDone();
    }
}
