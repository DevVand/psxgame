using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideSound : MonoBehaviour
{
    [SerializeField] AudioClip[] impact;
    [SerializeField] AudioClip[] stay;

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
    private void playAudio(Collision collision) {
        audioSource.clip = stay[Random.RandomRange(0, stay.Length)];
        audioSource.pitch = Random.RandomRange(.65f, .88f);
        audioSource.volume = collision.relativeVelocity.magnitude / 3;
        audioSource.Play();
    }
}
