using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightOn : MonoBehaviour
{
    public GameObject inttext, lightObject; // Renamed 'light' to 'lightObject'
    public bool toggle = false; // Initialize toggle to false (light off)
    public bool interactable;
    public Renderer lightBulb;
    public Material offlight, onlight;
    public AudioSource lightSwitchSound;
    public Animator switchAnim;
    public Light pointLight; // Reference to the point light component

    void Start()
    {
        // Turn off the light at the start of the game
        SetLightState(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(false);
            interactable = false;
        }
    }

    void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.E))
        {
            toggle = !toggle;
            // Play sound and trigger animation if the AudioSource is assigned
            if (lightSwitchSound != null)
                lightSwitchSound.Play();

            switchAnim.ResetTrigger("press");
            switchAnim.SetTrigger("press");

            // Update the state of both lights
            SetLightState(toggle);
        }
    }


    void SetLightState(bool state)
    {
        toggle = state;
        lightObject.SetActive(state);
        lightBulb.material = state ? onlight : offlight;
        pointLight.enabled = state;
    }
}
