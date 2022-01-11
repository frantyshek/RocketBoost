using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

    [SerializeField] GameObject settingsMenu;

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Back();
        }    
    }

    public void Back()
    {
        settingsMenu.SetActive(false);
    }
}
