using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20f;
     
    [SerializeField] ParticleSystem muzzleFlash;

    [SerializeField] GameObject hitEffect;

    [SerializeField] Ammo ammoSlot;

    [SerializeField] AmmoType ammoType; 

    [SerializeField] float timeBetweenFrames=0.5f;

    [SerializeField] TextMeshProUGUI ammoText;

    [SerializeField] AudioClip audioClip;

    AudioSource audioSource;

    bool canShoot = true;



    private void OnEnable()
    {
        canShoot = true;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
   

    void Update()
    {
        DisplayAmmo();
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }


    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();  
    }


    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            audioSource.PlayOneShot(audioClip, 0.1f);
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenFrames);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit; // the object that raycast hits
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;// if it is "NullReferenceException: Object reference not set to an instance of an object" in the console
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
      GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));// hit.point is the point of the his, hit.transform.position is the position of hit not the point.
        Destroy(impact, 0.1f);
    }
}
