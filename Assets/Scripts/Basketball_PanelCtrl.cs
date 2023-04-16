using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Basketball_PanelCtrl : MonoBehaviour
{
    public GameObject panel;

    public void OpenLevel(string loadScene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(loadScene);
        panel.SetActive(false);
        Basketball_Health.createBall = true;
        Basketball_ScoreCtrl.score = 0;
    }
}
