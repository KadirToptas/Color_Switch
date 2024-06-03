using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, ball.position.y, transform.position.z);
        }
    }
}

