using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class Trigger : MonoBehaviour
{
    public AudioSource playsound;
    private bool hasplayed = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!hasplayed)
        {
            playsound.Play();
            hasplayed = true;
        }
        else
        {
        gameObject.GetComponent<Collider>().enabled = false;

        }

    }
}
