using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour
{
    [SerializeField] GameObject levelSelectMenu;
    [SerializeField] Button level02Button;
    int levelPassed;

    void Start()
    {
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        level02Button.interactable = false;

        switch(levelPassed)
        {
            case 1:
                level02Button.interactable = true;
                break;
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
        levelSelectMenu.SetActive(false);
    }
}
