using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    [SerializeField] GameObject levelSelectMenu;
    [SerializeField] GameObject settingsMenu;

    public void Play()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void levelSelect()
    {
        levelSelectMenu.SetActive(true);
    }

    public void Settings()
    {
        settingsMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
