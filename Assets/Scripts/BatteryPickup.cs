using UnityEngine;
using System.Collections;

public class BatteryPickup : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Destroy(gameObject);
            //or gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
