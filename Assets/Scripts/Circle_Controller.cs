using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CircleController : MonoBehaviour
{
    public float speed = 100f; 
    public bool direction = false; 

    void Update()
    {
        float rotationSpeed = speed * Time.deltaTime;
        if (direction == false)
        {
            transform.Rotate(0, 0, rotationSpeed);
        }
        else
        {
            transform.Rotate(0, 0, -rotationSpeed);
        }
    }
}


