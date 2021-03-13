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
        flashTimer = (1.0f - Mathf.Clamp01(fCharge)) * fRunTimeFullCharge;
        Debug.Log(fTimer);
    }

    void Start()
    {
        Light light = GetComponent<Light>();
        fMaxIntensity = light.intensity;
        chargeLevel = 1.0f;
    }

    void Update()
    {
        if (flashTimer < 0.0f || flashTimer > fRunForTimeFullCharge)
            return;
        chargeLevel = flashTimer / fRunTimeFullCharge;
        light.intensity = ac.Evaluate(chargeLevel);
        flashTimer += Time.deltaTime;
    }
}