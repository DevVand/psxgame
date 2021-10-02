using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    public string name;
    [SerializeField] Transform pos;

    public Pickup pickup;
    private Menu menu;
    public UseDelegator usescript;


    private void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
        pickup = GameObject.FindGameObjectWithTag("Player").GetComponent<Pickup>();
        usescript = GetComponent<UseDelegator>();
        usescript.use = placeBook;
    }

    public void placeBook()
    {
        for (int i = 0; i <= 1; i++)
        {
            if (pickup.carrying[i] && pickup.carriedObject[i].GetComponent<Book>() != null)
            {
                if (pickup.carriedObject[i].GetComponent<Book>().name == name)
                {

                    pickup.carriedObject[i].GetComponent<Book>().goTo(pos);

                    pickup.letGo(i);
                }
                else
                {
                    menu.message("wrongShelf");
                }
            }
        }

    }
}
