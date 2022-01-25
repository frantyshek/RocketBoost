using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    [SerializeField] GameObject settingsMenu;

    [SerializeField] AudioMixer audioMixer;

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

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);  
    }
}
