using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDestroyer : MonoBehaviour
{
    [SerializeField] Switch my_switch;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (my_switch.isOn() && other.gameObject.GetComponent<EnemyMovement>().hunting)
            {
                my_switch.ForceOff();
            }
        }
    }
}
