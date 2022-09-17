using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    
    public Transform checkPoint;
    public GameObject ball;
    private float ballSpeed = 1f;

    private void Start()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var screenPoint = (Input.mousePosition);
            screenPoint.z = 10.0f; //distance of the plane from the camera
            transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
        }

        if (Input.GetMouseButton(0))
        {
            ballSpeed += ballSpeed + Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Instantiate(ball, checkPoint.position, Quaternion.identity);
        }
        
    }
}
