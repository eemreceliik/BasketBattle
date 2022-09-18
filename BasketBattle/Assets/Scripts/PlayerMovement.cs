using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody heroRb;

    private void Start()
    {
        heroRb = GetComponent<Rigidbody>();
    }


}
