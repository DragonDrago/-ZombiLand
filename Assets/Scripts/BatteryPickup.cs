using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 60f;
    [SerializeField] float intensityAmount = 9f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashLightSystem>().RestoreAngle(restoreAngle);
            other.GetComponentInChildren<FlashLightSystem>().AddLightIntensity(intensityAmount);
            Destroy(gameObject);
        }
    }
}
