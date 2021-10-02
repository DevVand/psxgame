using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : MonoBehaviour
{

    private Menu menu;
    public UseDelegator usescript;

    [SerializeField] AudioClip flushSound;
    private bool flushed=false;

    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
        usescript = GetComponent<UseDelegator>();
        usescript.use = flush;
    }

    public void flush() {
        if (!flushed)
        {
            menu.toiletDone();
            flushed = true;
        }
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(flushSound);
    }
}
