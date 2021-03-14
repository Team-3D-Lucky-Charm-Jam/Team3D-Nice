using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IntroSceneScript : MonoBehaviour
{
    public AudioSource aSource;
    public AudioClip ac;
    public string nextScene;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        aSource.PlayOneShot(ac);
        time = ac.length;
        Invoke("NextScene", time); 
    }

    void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

   
}
