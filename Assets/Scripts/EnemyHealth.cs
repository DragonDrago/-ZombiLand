using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;

    RadarSystem radarSystem;

  

    public bool IsDead()
    {
        return isDead; 
    }
    public void TakeDamage(float damage)
    {
        // => GetComponent<EnemyAI>().OnDamageTaken(); it is just one way to alert enemy when it gets shoot from player
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }
}
