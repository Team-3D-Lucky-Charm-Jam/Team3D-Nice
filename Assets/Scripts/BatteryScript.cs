using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Flashlight : MonoBehaviour
{
    public float fRunTimeForFullCharge = 900.0f;
    public AnimationCurve ac = new AnimationCurve();

    float flashTimer = 0.0f;
    float fMaxIntensity;
    public float chargeLevel; // Can't set level here

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
        chargeLevel = flashTimer / fRunTimeForFullCharge;
        GetComponent<Light>().intensity = ac.Evaluate(chargeLevel);
        flashTimer += Time.deltaTime;
    }
}