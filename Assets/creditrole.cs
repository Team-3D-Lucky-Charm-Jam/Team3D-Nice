using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class creditrole : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip ac;
    public Transform transfo;
    public float speedRole = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        audioS.PlayOneShot(ac);
    }

    // Update is called once per frame
    void Update()
    {
        transfo.position = new Vector3(transfo.position.x, transfo.position.y + speedRole * Time.deltaTime, transform.position.z);
    }
}
