using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isInside : MonoBehaviour
{
    public tutorial0 tutorial;
    private int inside = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactive") {
            inside++;
        }
        if (inside == 2)
        {
            tutorial.finished();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inside--;
    }
}
