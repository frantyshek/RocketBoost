using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour
{

    [SerializeField] Button[] levelButtons;

    void Start()
    {
        int levelUnlocked = PlayerPrefs.GetInt("LevelUnlocked", 1);
        
        for(int i = 0; i < levelButtons.Length; i++)
        {
            if(i + 1 > levelUnlocked)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }

    public void LevelToLoad(int Level)
    {
        SceneManager.LoadScene(Level);
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
