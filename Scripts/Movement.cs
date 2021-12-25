using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;

    [SerializeField] float speed = 100f;
    [SerializeField] float rotateSpeed = 100f;
    [SerializeField] ParticleSystem mainParticles;

    bool IsGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveForward();
        Rotate();        
    }

    void MoveForward()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StartMovingForward();
        }
        else
        {
            StopMovingForward();
        }
    }

    void StartMovingForward()
    {
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
}

