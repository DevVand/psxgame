using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsManager : MonoBehaviour
{
    [SerializeField] Options options;
    [SerializeField] AudioMixer mixer;
    PlayerMovement playerMove;
    [SerializeField] PlayerCamera playerCam;

    [SerializeField] Slider vol;
    [SerializeField] Slider mouseSens;
    [SerializeField] Toggle motionSick;
    void Start()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        updateVol();
        updateMouseSens();
        updateMotionSick();
    }

    public void applyVol()
    {
        options.vol = vol.value;
        updateVol();
    }
    public void updateVol()
    {
        vol.value = options.vol;
        mixer.SetFloat("Vol",options.vol);
    }
    public void applyMouseSens() {
        options.mouseSensibility = mouseSens.value;
        updateMouseSens();
    }
    public void updateMouseSens() {
        mouseSens.value = options.mouseSensibility;
        playerCam.changeSensibility(options.mouseSensibility);
    }
    public void applyMotionSick()
    {
        options.motionSicknessMode = motionSick.isOn;
        updateMotionSick();
    }
    public void updateMotionSick()
    {
        motionSick.isOn = options.motionSicknessMode;
        playerMove.motionSicknessMode(options.motionSicknessMode);
    }
}
