using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControll : MonoBehaviour
{

    public float ballSpeed;
    private Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
        
    }


    private void Update()
    {
        _rb.velocity = new Vector3(1, 0, 0) * ballSpeed;
    }
}