using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 0.2f;
    [SerializeField] float minimumAngle = 30f;

    Light myLight;

    private void Start()
    {
        myLight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    

    public void RestoreAngle(float restoreAngle)
    {
        myLight.spotAngle = restoreAngle;
    }

    public void AddLightIntensity(float intensityAmount)
    {
        myLight.intensity += intensityAmount;
    }

    private void DecreaseLightIntensity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime; ;
    }

    private void DecreaseLightAngle()
    {
        if (myLight.spotAngle <= minimumAngle)
        {
            return;// qaysi holatda tursa oshanday qoldir degani
        }
        else
        {
            myLight.spotAngle -= angleDecay * Time.deltaTime;
        }
    }
}
