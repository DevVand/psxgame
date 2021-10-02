using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLeveler : MonoBehaviour
{
    public AudioSource[] audios;
    private Transform player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (AudioSource audio in audios)
        {
            audio.volume = 1 / Mathf.Abs(player.position.y - transform.position.y);
        }
    }
}
