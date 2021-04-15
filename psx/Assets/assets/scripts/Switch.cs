using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] Light lamp;
    [SerializeField] float onintensity;
    [SerializeField] float offintensity;
    [SerializeField] AudioSource switchsound;

    public UseDelegator usescript;
    // Start is called before the first frame update
    void Start()
    {
        usescript = GetComponent<UseDelegator>();
        usescript.use = turnonoff;
    }

    public void turnonoff() {
        if (lamp.intensity == onintensity)
        {
            lamp.intensity = offintensity;
            switchsound.Play();
        }
        else
        {
            lamp.intensity = onintensity;
            switchsound.Play();
        }
    }
}
