using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    public Pause pause;


    public void back ()
    {
        pause.ContinueGame();
    }
}
