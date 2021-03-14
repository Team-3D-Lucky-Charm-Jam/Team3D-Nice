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
        Invoke("QuitGame", ac.length);
    }

    void QuitGame()
    {
        #if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    // Update is called once per frame
    void Update()
    {
        transfo.position = new Vector3(transfo.position.x, transfo.position.y + speedRole * Time.deltaTime, transform.position.z);
    }
}
