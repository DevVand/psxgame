using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDestroyer : MonoBehaviour
{
    [SerializeField] Switch my_switch;

    private void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemy= other.gameObject.GetComponent<EnemyMovement>();
        if (enemy != null) {
            if (my_switch.isOn() && enemy.hunting)
                my_switch.ForceOff();
        }
    }
}
