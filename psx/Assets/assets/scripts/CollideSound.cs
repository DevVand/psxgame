using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideSound : MonoBehaviour
{
    [SerializeField] AudioClip[] impact;

    [SerializeField] float enterSensibility = .8f;
    [SerializeField] float staySensibility = 3;

    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.relativeVelocity.magnitude);

        if (collision.relativeVelocity.magnitude > enterSensibility) {
            playAudio(collision);
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > staySensibility)
        {
            playAudio(collision);
        }
    }

    private void playAudio(Collision collision)
    {
        audioSource.pitch = Random.Range(.65f, .88f);
        audioSource.PlayOneShot(impact[Random.Range(0, impact.Length)], collision.relativeVelocity.magnitude / 3);
    }
}
