using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitcher : MonoBehaviour
{
    bool flashing = false;

    [SerializeField] GameObject flashLight;
    
    // Start is called before the first frame update
    void Start()
    {
        flashLight = GetComponentInChildren<GameObject>();
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashing == false)
            {
                FlashingOn();
            }
            else
            {
                FlashingOff();
            }
        }
    }


    private void FlashingOff()
    {
        flashing = false;
        flashLight.SetActive(false);
    }

    private void FlashingOn()
    {
        flashing = true;
        flashLight.SetActive(true);
    }
}
