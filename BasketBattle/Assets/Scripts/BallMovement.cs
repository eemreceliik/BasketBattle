using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform stripPosition;
    public Transform center;
    public Transform idlePosition;
    public Transform rightHand, leftHand, pelvis;
    public Transform ballRight, ballLeft, ballPelvis;

    public Vector3 currentPosition;

    public float maxLength;

    public float bottomBoundary;
    public float force;
    

    private Rigidbody _rb;
    private Collider _collider;

    public Rigidbody heroRb;
    private void Start()
    {
        heroRb = heroRb.gameObject.GetComponent<Rigidbody>();
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<SphereCollider>();
        lineRenderer.positionCount = 2;
        lineRenderer.gameObject.SetActive(false);
        heroRb.useGravity = true;
    }

    private void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            SetTransform();
            SetMousePosition();
            SetVelocity();
            lineRenderer.gameObject.SetActive(true);
        }*/

        if (Input.GetMouseButton(0))
        {
            SetTransform();
            SetMousePosition();
            SetVelocity();
            lineRenderer.gameObject.SetActive(true);
        }
        if(Input.GetMouseButtonUp(0))
        {
            Shoot();
            ForcePlayer();
            ResetStrip();
            lineRenderer.gameObject.SetActive(false);
        }
    }
    

    private void ResetStrip()
    {
        
        currentPosition = idlePosition.position;
        SetStrip(currentPosition);
    }

    private void SetStrip(Vector3 position)
    {
        lineRenderer.SetPosition(1,position);
    }

    Vector3 ClampBoundary(Vector3 vector)
    {
        vector.y = Mathf.Clamp(vector.y, bottomBoundary, 100);
        return vector;
    }

    private void Shoot()
    {
        var ballForce = (currentPosition - center.position) * force;
        _rb.velocity = ballForce;
    }

    private void SetMousePosition()
    {
        lineRenderer.SetPosition(0,stripPosition.position);

        var mousePosition = Input.mousePosition;
        mousePosition.z = 10;

        currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        currentPosition = center.position + Vector3.ClampMagnitude(currentPosition - center.position, maxLength);
        currentPosition = ClampBoundary(currentPosition);
            
        SetStrip(currentPosition);
    }

    private void SetVelocity()
    {
        _rb.velocity = new Vector3(0.1f,0.1f,0);
    }

    private void SetTransform()
    {
        rightHand.position = ballRight.position;
        leftHand.position = ballLeft.position;
        pelvis.position = ballPelvis.position;
    }

    private void ForcePlayer()
    {
        var playerForce = (currentPosition - center.position) * (force * -3);
        heroRb.velocity = playerForce;

    }
    
}
