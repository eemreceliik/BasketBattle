using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isTouch = false;
    public GameObject particle;
    public GameObject canvas;
    private int count;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag($"Ball"))
        {
            if (isTouch)
            {
                particle.gameObject.SetActive(true);

                particle.gameObject.GetComponent<ParticleSystem>().Play();

                if (count<3)
                {
                    canvas.gameObject.transform.GetChild(count).gameObject.SetActive(true);

                    count++;
                }
            }
 
            isTouch = false;

        }
    }
}

