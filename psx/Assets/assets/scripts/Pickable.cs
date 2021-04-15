using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public string type;
    // Start is called before the first frame update
    void Start()
    {
        if (type == "")
            type = "misc";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
