﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Climber : MonoBehaviour
{
    private CharacterController character;
    public static XRController climbingHand;
    private ContinuousMoveProviderBase continuosMovement;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        continuosMovement = GetComponent<ContinuousMoveProviderBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if(climbingHand)
        {
            continuosMovement.enabled = false;
            Climb();
        }
        else
        {
            continuosMovement.enabled = true;
        }
    }

    void Climb()
    {
        InputDevices.GetDeviceAtXRNode(climbingHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);
        character.Move(transform.rotation * -velocity * Time.fixedDeltaTime);

    }
}
