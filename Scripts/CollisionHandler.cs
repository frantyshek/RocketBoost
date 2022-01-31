using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float timeToReload = 1f;
    [SerializeField] ParticleSystem mainParticles;
    AudioSource audioRocket; 

    bool NoCollision;

    void Start()
    {
        audioRocket = GetComponent<AudioSource>();
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
        mainParticles.Stop();
        audioRocket.Stop();
        if(SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("LevelUnlocked"))
        {
            PlayerPrefs.SetInt("LevelUnlocked", SceneManager.GetActiveScene().buildIndex + 1);
        }
        Invoke("NextLevel", timeToReload);
    }

    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings -1)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
