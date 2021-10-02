using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public GameObject parentBalde;
    public bool isFull = false;

    [SerializeField] AudioClip[] sound;
    AudioSource audioSource;

    private Menu menu;
    private Pickup pickup;
    public UseDelegator usescript;
    private void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
        pickup = GameObject.FindGameObjectWithTag("Player").GetComponent<Pickup>();
        audioSource = GetComponent<AudioSource>();

        usescript = GetComponent<UseDelegator>();
        usescript.use = LimpaVassoura;
    }

    public void EsvaziaBalde ()
    {
        parentBalde.transform.GetChild(0).gameObject.SetActive(false);
        isFull = false;
    }

    public void EncheBalde ()
    {
        parentBalde.transform.GetChild(0).gameObject.SetActive(true);
        isFull = true;
    }

    public void LimpaVassoura()
    {
        
            for (int i = 0; i <= 1; i++)
            {
                if (pickup.carrying[i] && pickup.carriedObject[i].GetComponent<Broom>() != null)
                {
                if (isFull)
                {
                    playAudio();
                    EsvaziaBalde();
                    pickup.carriedObject[i].GetComponent<Broom>().LimpaVassoura();
                }else{
                    menu.message("emptyBucket");
                }
            }
        } 

    }
    public void playAudio()
    {
        audioSource.clip = sound[Random.Range(0, sound.Length)];
        audioSource.pitch = Random.Range(.7f, .88f);
        audioSource.Play();
    }

}
