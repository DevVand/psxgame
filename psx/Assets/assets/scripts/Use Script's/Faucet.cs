using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faucet : MonoBehaviour
{
    private Pickup pickup;
    public UseDelegator usescript;

    [SerializeField] AudioClip audio;
    AudioSource audioSource;
    private void Start()
    {
        pickup = GameObject.FindGameObjectWithTag("Player").GetComponent<Pickup>();
        audioSource = GetComponent<AudioSource>();
        usescript = GetComponent<UseDelegator>();

        usescript.use = EncherComAgua;
    }

    public void EncherComAgua()
    {
        for (int i = 0; i <= 1; i++)
        {
            if (pickup.carrying[i] && pickup.carriedObject[i].GetComponent<Bucket>() != null)
            {
                audioSource.PlayOneShot(audio, 1);
                pickup.carriedObject[i].GetComponent<Bucket>().EncheBalde();
            }
        }
    }

}
