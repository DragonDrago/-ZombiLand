using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

    [SerializeField] int extraAmmoAmount = 10;

    [SerializeField] AmmoType ammoType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")// it it the other game objects on the scene
        {
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType, extraAmmoAmount);
            Destroy(gameObject); // this  is for the game object that the script installed on.
        }
    }
}
