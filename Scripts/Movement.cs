using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    Rigidbody rb;

    [SerializeField] float speed = 100f;
    [SerializeField] float rotateSpeed = 100f;
    [SerializeField] ParticleSystem mainParticles;
    [SerializeField] GameObject pauseScreen;

    bool IsGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveForward();
        Rotate();
        Pause();        
    }

    void MoveForward()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StartMovingForward();
        }
        else
        {
            //Just to stop the particles and audio
            StopMovingForward();
        }
    }

    void StartMovingForward()
    {
        //Movement so if players hits space the rocket will thrust
        rb.AddRelativeForce(Vector3.up * speed * Time.deltaTime);
            if(!mainParticles.isEmitting)
            {
              mainParticles.Play();  
            }
    }

    void StopMovingForward()
    {
            mainParticles.Stop();
    }

    void Rotate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            RotationMethod(rotateSpeed);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            RotationMethod(-rotateSpeed);       
        }
    }

    void RotationMethod(float rotationPower)
    {
        //Player can not rotate when the rocket is on the ground(start/checkpoint)
        if(!IsGrounded)
        {
            rb.freezeRotation = true;
            transform.Rotate(Vector3.forward * rotationPower * Time.deltaTime);
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Start")
        {
            IsGrounded = true;
        }        
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Start")
        {
            IsGrounded = false;
        }    
    }

    void Pause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
          pauseScreen.SetActive(true);
          Time.timeScale = 0f;  
        }
    }

    void PauseButton()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}

