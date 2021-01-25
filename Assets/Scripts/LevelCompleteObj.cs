using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteObj : MonoBehaviour
{
    [SerializeField] GameObject completeLevelOBJ;
    [SerializeField] GameObject displayAmmoCanvas;

 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            displayAmmoCanvas.SetActive(false);
            completeLevelOBJ.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;// at the beginning when u run the game the cursor is locked and when player is dead there is none value in lockCursorMode
            Cursor.visible = true;
            Destroy(gameObject);
        }
    }

}
