using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;// it is the reference for the objects that PlayerhHealth in, 

    [SerializeField] float damage = 20f;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }


    public void OnDamageTaken()// it is just to play, however it is called or broadcasted in EnemyHealth.cs
    {
        Debug.Log(name + " I also know that we took damage");
    }

    public void AttackHitEvent()
    {

        if (target == null) return;
        target.TakeDamage(damage);
        target.GetComponent<DisplayDamage>().ShowDamageImpact();// if PlayerHealth inside the object, the Display damage also inside it;
        // or just we can write =>   PlayerHealth healthTarget = target.GetComponent<PlayerHealth>();
        // and =>   healtTarget.TakeDamage(damage);
        // or just=> target.GetComponent<PlayerHealth>().TakeDamage(damage);
    }

}
