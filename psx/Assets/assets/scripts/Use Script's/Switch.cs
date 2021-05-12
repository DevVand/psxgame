using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] Light[] lamps;
    [SerializeField] float onintensity;
    [SerializeField] float offintensity;
    [SerializeField] AudioSource switchsound;
    [SerializeField] AudioSource explodesound;

    public UseDelegator usescript;
    // Start is called before the first frame update
    void Start()
    {
        usescript = GetComponent<UseDelegator>();
        usescript.use = turnonoff;
    }

    public void turnonoff() {
        foreach ( Light lamp in lamps)
        {
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
    public void ForceOff()
    {
        foreach (Light lamp in lamps)
        {
            lamp.intensity = offintensity;
        }
        explodesound.Play();
    }
    public bool isOn() {
        return lamps[0].intensity == onintensity;
    }
}
