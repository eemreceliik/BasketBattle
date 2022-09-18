using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BallControll : MonoBehaviour
{

    //public float ballSpeed;
    private Rigidbody _rb;
    public Transform rightHand,leftHand,hero;
    public Transform ballRightHand, ballLefthHand, BallHero;
    public float speed = 1f;
    public GameObject player;
    private Rigidbody heroRb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        heroRb = player.GetComponent<Rigidbody>();
        //transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);


    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetPlayerPosition();

        }

        if (Input.GetMouseButton(0))
        {
            SetPlayerPosition();
            speed += speed * Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0))
        {
            var mousePosition = Input.mousePosition;
            mousePosition.z = 10;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            SetForce(mousePosition);
            PlayerSetForce(mousePosition);

        }

     

    }

    private void SetForce(Vector3 mousePosition)
    {
        _rb.velocity += mousePosition * speed;
    }
    private void PlayerSetForce(Vector3 mousePosition)
    {
        heroRb.velocity += (-mousePosition * speed)/2;
        speed = 1f;

    }

    private void SetPlayerPosition()
    {
        hero.position = BallHero.position - new Vector3(0, 0.6f, 0);
        rightHand.position = ballRightHand.position;
        leftHand.position = ballLefthHand.position;
        
    }


}
