using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Flashlight : MonoBehaviour
{
    public float fRunTimeForFullCharge = 450.0f;
    public AudioSource audioS;
    private bool playLowBatSoundClip = true;
    private bool playDeadSoundFlag = false;
    public AudioClip ac;
    public AudioClip resetAC;
    public AudioClip DeadAC;

    public float flashTimer = 1.5f;
    public float maxBright;
    public float lowTres;
    public float deadThresh;
    float fMaxIntensity;
    public float chargeLevel; // Can't set level here
    public float chargeIncrementer;

    public void SetChargeLevel(float fCharge)
    {
        flashTimer = (1.0f - Mathf.Clamp01(fCharge)) * fRunTimeForFullCharge;
        Debug.Log(flashTimer);
    }

    void Start()
    {
        Light light = GetComponent<Light>();
        fMaxIntensity = light.intensity;
        chargeLevel = 1.0f;
    }

    void Update()
    {
        if (flashTimer < 0.0f || flashTimer > fRunTimeForFullCharge)
            return;
        chargeLevel = flashTimer;
        if(chargeLevel < lowTres && playLowBatSoundClip && !playDeadSoundFlag)
        {
            if(ac != null)
            {
                audioS.PlayOneShot(ac);
            }
            
            playLowBatSoundClip = false;
            playDeadSoundFlag = true;
        }
        else if (chargeLevel < deadThresh && playDeadSoundFlag)
        {
            if(DeadAC != null)
            {
                audioS.PlayOneShot(DeadAC);
            }
            
            playDeadSoundFlag = false;
        }
        GetComponent<Light>().intensity = chargeLevel;
        flashTimer -= Time.deltaTime / fRunTimeForFullCharge;
    }

    public void ResetFlashTimer()
    {
        flashTimer = maxBright;
        //audioS.PlayOneShot(resetAC);
        playLowBatSoundClip = true;
    }

}