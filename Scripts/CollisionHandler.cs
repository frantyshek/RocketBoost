using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float timeToReload = 1f;
    [SerializeField] ParticleSystem mainParticles;
    AudioSource audioRocket; 
    
    int levelPassed;

    bool NoCollision;

    void Start()
    {
        audioRocket = GetComponent<AudioSource>();
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
    }

    void Update() 
    {  
        //Cheats hehe xd;
        if(Input.GetKeyDown(KeyCode.C))
        {
            NextLevel();
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            NoCollision = !NoCollision;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Start":
                break;
            case "Finish":
                Finishing();
                break;
            default:
                Crash();
                break;
        }
    }

    void Crash()
    {   
        if(!NoCollision)
        {
           GetComponent<PlayerController>().enabled = false;
            mainParticles.Stop();
            audioRocket.Stop();
            Invoke("ReloadLevel", timeToReload); 
        }
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void Finishing()
    {
        GetComponent<PlayerController>().enabled = false;
        Invoke("NextLevel", timeToReload);
    }

    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(levelPassed < currentSceneIndex)
        {
            PlayerPrefs.SetInt("LevelPassed", currentSceneIndex);
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
