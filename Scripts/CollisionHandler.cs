using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float timeToReload = 1f;
    [SerializeField] ParticleSystem mainParticles;
    
    bool NoCollision;

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
           GetComponent<Movement>().enabled = false;
            mainParticles.Stop();
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
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", timeToReload);
    }

    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if( nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
