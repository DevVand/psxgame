using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDoor : MonoBehaviour
{
    public Menu menu;
    public UseDelegator usescript;

    private void Start()
    {
        
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
        usescript = GetComponent<UseDelegator>();
        usescript.use = Conclusion;
        menu.deathMessage("start"); 
        StartCoroutine(nameof(update));
    }
     
    IEnumerator update()
    {
        while (true)
        {
            if (menu.allDone)
            {
                menu.deathMessage("exitTheHouse");
                StopCoroutine(nameof(update));
            }

            yield return .1f;
        }
    }
    private void Conclusion()
    {
        if (menu.allDone)
        {
            menu.fadeOut("");
            menu.dialogueMessage("victoryMessage");
        }
        else {
            menu.message("houseDirty");
        }
    }
}
