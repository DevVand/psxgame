using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeioMusic : MonoBehaviour
{
    public float smooth = 5;
    [SerializeField] EnemyMovement enemy;
    private AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.hunting) 
            music.volume = Mathf.Lerp(music.volume,.8f,Time.deltaTime * smooth);
        else 
            music.volume = Mathf.Lerp(music.volume, 0, Time.deltaTime * smooth);
    }
}
