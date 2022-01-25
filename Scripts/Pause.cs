using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Pause : MonoBehaviour
{
   
    [SerializeField] GameObject pauseScreen;
    [SerializeField] AudioMixer audioMixer;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;            
        }
    }

    public void Back()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
