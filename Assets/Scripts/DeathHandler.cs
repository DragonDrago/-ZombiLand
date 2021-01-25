using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas; 

    private void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;// at the beginning when u run the game the cursor is locked and when player is dead there is none value in lockCursorMode
        Cursor.visible = true;
    }
}
