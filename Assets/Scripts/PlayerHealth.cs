using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100;

    [SerializeField] TextMeshProUGUI healthText;
   
    [SerializeField] Image healthBarIMG;

    float PercentConvertor = 100;
 

   

    public void TakeDamage( float damage)
    {
        health -= damage;

        HealthBar();

        if (health <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();// we did not call it in start, and did not give reference because the the scripts inside the same gameObject
        }
    }

    private void HealthBar()
    {
        healthText.text = health.ToString() + "%";
        if (health < 0) health = 0;
        healthBarIMG.fillAmount = health / PercentConvertor;
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / PercentConvertor));
        healthBarIMG.color = healthColor;
    }
}
