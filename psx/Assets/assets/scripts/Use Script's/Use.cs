using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use : MonoBehaviour
{
    [SerializeField] Animator crossair;
    [SerializeField] float maxDist =2;
    public LayerMask layer;
    void Update()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDist,layer))
        {
            if (hit.collider.tag == "Interactive")
            {
                crossair.SetBool("open", true);
                if (Input.GetButtonDown("Use"))
                {
                    hit.collider.GetComponent<UseDelegator>().use();
                }
            }
            else
            {
                crossair.SetBool("open", false);
            }
        }
        else
        {
            crossair.SetBool("open", false);
        }
    }
}
