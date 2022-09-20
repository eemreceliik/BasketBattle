using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public bool isTouch = false;
    public GameObject particle,canvas,levelUI,ball,hero;
    
    private int count;


    private void Update()
    {
        if (count==3)
        {
            Invoke(nameof(GetLevelUI),0.7f);
        }
    }

    private void GetLevelUI()
    {
        Time.timeScale = 0;
        ball.SetActive(false);
        hero.SetActive(false);
        levelUI.SetActive(true);
    }

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
                    canvas.gameObject.transform.GetChild(0).GetChild(count).GetChild(0).gameObject.SetActive(true);

                    count++;
                }
            }
            isTouch = false;

        }
    }

    public void NextLevelButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void RestartLevelButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }
}

