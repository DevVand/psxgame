using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "options")]
public class Options : ScriptableObject
{
    [Range(-80, 20)]
    public float vol= 0;
    [Range(0.1f,3.5f)]
    public float mouseSensibility = 0.5f;
    public bool motionSicknessMode = false;
}
