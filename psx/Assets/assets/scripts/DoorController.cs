using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator doorAnim;
    private bool doorOpen = false;

    public UseDelegator usescript;

    private void Start()
    {
        doorAnim = gameObject.GetComponent<Animator>();
        usescript = GetComponent<UseDelegator>();
        usescript.use = PlayAnimation;
    }

    public void PlayAnimation()
    {

        if (!doorOpen)
        {
            doorAnim.SetBool("open", true);
            doorOpen = true;
        }
        else if (doorOpen)
        {
            doorAnim.SetBool("open", false);
            doorOpen = false;
        }
    }
     public void ForceOpen()
    {
        if (!doorOpen)
        {
            doorAnim.SetBool("open", true);
            doorOpen = true;
        }
    }
}
