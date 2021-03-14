using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playtape : MonoBehaviour
{
    public AudioSource aSource;
    public AudioClip ac;


    public void PlayAudio()
    {
        if(aSource != null)
        {
            if(ac != null)
            {
                aSource.PlayOneShot(ac);
            }
        }
    }
}
