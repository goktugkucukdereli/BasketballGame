using System;
using System.Collections;
using System.Collections.Generic;
using Pota;
using Unity.VisualScripting;
using UnityEngine;

public class Basketball_Tutorial : MonoBehaviour
{
    public GameObject hand, left, right, tutorialPanel, gameManager;
    private bool isEnabled=false;

    private void Start()
    {
        gameManager.GetComponent<Basketball_BallCtrl>().enabled = true;
        Toggle(false);
        tutorialPanel.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball_Tutorial")
        {
            Toggle(true);
        }

        if (Score.score >= 3 && HoopController.isTutorial)
        {
            tutorialPanel.SetActive(true);
            Basketball_Health.createBall = false;
        }

    }

    private void Update()
    {
        if(isEnabled==true && HoopController.isFirstTouchMade==true)
            Toggle(false);
    }

    public void Toggle(bool toggle)
    {
        isEnabled = toggle;
        hand.SetActive(toggle);
        left.SetActive(toggle);
        right.SetActive(toggle);
        //GetComponent<Animator>().enabled = toggle;
    }

}