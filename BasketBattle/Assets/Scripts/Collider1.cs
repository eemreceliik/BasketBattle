using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider1 : MonoBehaviour
{
    public GameObject collider2;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag($"Ball"))
        {
            collider2.gameObject.GetComponent<GameManager>().isTouch=true;
            Invoke(nameof(Test),0.5f);

        }

    }

    private void Test()
    {
        collider2.gameObject.GetComponent<GameManager>().isTouch=false;

    }
}
