using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    // Start is called before the first frame update
    Light flash;
    private bool isFlickering = false;
    void Start()
    {
        flash = GetComponent<Light>();
       flash.intensity = 0f;
        InvokeRepeating("ToggleFlicker", 3f, 0f);
    }

    void ToggleFlicker()
    {
        isFlickering = !isFlickering;
        if (isFlickering)
        {
            // Nyalakan cahaya
            flash.intensity = 5f;
        }
        else
        {
            // Matikan cahaya
            flash.intensity = 1f;
        }
    }

}
