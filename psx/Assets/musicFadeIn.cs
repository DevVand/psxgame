using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicFadeIn : MonoBehaviour
{
    public float smooth = .2f;
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audio.volume = Mathf.Lerp(audio.volume, .7f, Time.deltaTime * smooth);
    }
}
