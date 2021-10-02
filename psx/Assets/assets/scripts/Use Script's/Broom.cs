using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour
{
    public int cleanFactor = 6;
    public int cleaness;


    [SerializeField] AudioClip[] sound;
    AudioSource audioSource;


    private Menu menu;
    public Animator anim;
    private Pickup pickup;
    public GameObject parentVassoura;
    public UseDelegator usescript;

    
    private void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        pickup = GameObject.FindGameObjectWithTag("Player").GetComponent<Pickup>();
        audioSource = GetComponent<AudioSource>();
        cleaness = cleanFactor;
        usescript = GetComponent<UseDelegator>();
        usescript.use = Vassoura;
    }

    public void Vassoura()
    {
        for (int i = 0; i <= 1; i++)
        {
            if (pickup.carrying[i] && pickup.carriedObject[i].GetComponent<Bucket>() != null)
            {
                Bucket bucket = pickup.carriedObject[i].GetComponent<Bucket>();
                if (bucket.isFull)
                {
                    bucket.EsvaziaBalde();
                    bucket.playAudio();
                    LimpaVassoura();
                } else {
                    menu.message("emptyBucket");
                }
            }
        }
    }
 

    public void LimpaVassoura() {
        cleaness = cleanFactor;
        parentVassoura.transform.GetChild(0).gameObject.SetActive(false);
    }
    public void SujaVassoura() {
        if (cleaness <= 0)
            parentVassoura.transform.GetChild(0).gameObject.SetActive(true);
        else
            cleaness -= 1;
        }

    public void playAudio() {
        audioSource.clip = sound[Random.Range(0, sound.Length)];
        audioSource.pitch = Random.Range(.7f, .88f);
        audioSource.Play();
    }

    public void swash(int i) {
        //anim.Play("Empty" + i);
        anim.Play("swash" + i,-1,0);
    }

        public bool isClean() { return cleaness > 0; }
}
