using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Flashlight : MonoBehaviour
{
    public float fRunTimeForFullCharge = 300.0f;
    public AnimationCurve ac = new AnimationCurve();

    float flashTimer = 1.0f;
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
        GetComponent<Light>().intensity = chargeLevel;
        flashTimer -= Time.deltaTime / fRunTimeForFullCharge;
    }

    public void ResetFlashTimer()
    {
        flashTimer = 1.0f;
    }

}