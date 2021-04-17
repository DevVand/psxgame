using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stepsound : MonoBehaviour
{
    public AudioSource[] sounds;
 
    public void step() {
        sounds[Random.Range(0,sounds.Length)].Play();
    }
}
