using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if(period == 0)
        {
            return;
        }
        float cycles = Time.time / period; //growing over time

        const float value = Mathf.PI * 2; //constant value of 2Pi
        float rawSinWave = Mathf.Sin(cycles * value); //value between -1 and 1

        movementFactor = (rawSinWave + 1) / 2f; //we made this to have value between 0 and 1, so it will start moving from the start position and it will also come back to start position and it won't go any further

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;

    }
}
