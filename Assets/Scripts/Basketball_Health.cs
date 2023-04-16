using System;
using System.Collections;
using System.Collections.Generic;
using Pota;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Basketball_Health : MonoBehaviour
{
    public static bool createBall = true;
    public GameObject menuIcon;
    public GameObject tryAgain;
    public GameObject pauseIcon;
    public GameObject circle;
    public GameObject maps;
    public GameObject health;
    public GameObject content;
    public GameObject[] allHealth;
    public int hoopHealth;

    private void Awake()
    {
        createBall = !HoopController.isTutorial;
    }

    void Start()
    {
        allHealth = new GameObject[hoopHealth];
        for (int i = 0; i < hoopHealth; i++)
        {
            GameObject g = Instantiate(health, maps.transform);
            g.transform.SetParent(content.transform);
            allHealth[i] = g;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.GetComponent<Ball>().Count && hoopHealth > 0) { 
            hoopHealth--;
            allHealth[hoopHealth].SetActive(false);
            Basketball_AudioManager.aManager.noVoice();
        }

        else if (hoopHealth <= 0)
        {
            allHealth[0].SetActive(false);
            gameObject.SetActive(false);
            circle.SetActive(false);
            createBall = false;
            tryAgain.SetActive(true);
            pauseIcon.SetActive(false);
            menuIcon.SetActive(false);
        }

        Destroy(other.gameObject);
    }
}
