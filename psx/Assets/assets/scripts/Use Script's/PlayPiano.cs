using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPiano : MonoBehaviour
{
    public Stepsound sound;
    public EnemyMovement enemy;
    public UseDelegator usescript;

    void Start()
    {
        usescript = GetComponent<UseDelegator>();
        usescript.use = Play;
    }

    // Update is called once per frame
    public void Play()
    {
        enemy.newDestination(transform.position);
        sound.step();
    }
}
