using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fart : MonoBehaviour
{
    private AudioSource audio;
    [SerializeField] AudioClip[] sounds;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fart")) {
            audio.PlayOneShot(sounds[Random.RandomRange(0,sounds.Length)], .3f);

        }

    }
}
