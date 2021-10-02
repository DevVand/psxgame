using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerCaller : MonoBehaviour
{
    public VeioTrigger script;

    public void callDialogue() {
        script.callDialogue();
    }
}
