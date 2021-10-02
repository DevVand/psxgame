using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideVeio : MonoBehaviour
{
    public Menu menu;
    private Collider collider;

    [SerializeField] AudioSource[] audios;
    [SerializeField] AudioClip sound;
    AudioSource audio;

    private void Start()
    {
        collider = GetComponent<Collider>();
        audio = GetComponent<AudioSource>();
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(nameof(mute));
            audio.PlayOneShot(sound, 1);
            menu.fadeJump(1);
            Invoke(nameof(reset), 3f);
            collider.enabled = false;

        }
    }
    public void reset()
    {
        menu.loadGame();
    }
    IEnumerator mute() {
        while (true)
        {
            for (int i = 0; i < audios.Length; i++)
            {
                if (audios[i] != null)
                {
                    audios[i].volume = 0;
                    audios[i].Stop();
                }
            }
            yield return null;
        }
    }
}
