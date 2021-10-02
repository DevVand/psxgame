using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDistance : MonoBehaviour
{
    private Transform player; private Menu menu;

    public float distance;
    private bool reached = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!reached)
        {
            if (Vector3.Distance(player.position, transform.position) > distance)
            {
                reached = true;
                menu.fadeOut("FunnyClose");
            }
        }
    }
}
