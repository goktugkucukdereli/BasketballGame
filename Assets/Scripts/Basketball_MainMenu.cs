using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Basketball_MainMenu : MonoBehaviour
{
    public GameObject playButton;
    public GameObject exitButton;
    public Text scoreText;
    public Text highscoreText;

    private void Update()
    {
        //scoreText.text = "Score: " + PlayerPrefs.GetInt("basketball_Score").ToString();
        //highscoreText.text = "High Score: " + PlayerPrefs.GetInt("basketball_HighScore").ToString();
    }

    public void Play()
    {
        if(PlayerPrefs.GetInt("Basketball_tutorialSave", 0) == 0)
        {
            PlayerPrefs.SetInt("Basketball_tutorialSave", 1);
            SceneManager.LoadScene("Basketball_Tutorial");
        }
        else
        {
            SceneManager.LoadScene("Basketball_Game");
        }
    }

    public void OpenLevel(string loadScene) 
    {
        SceneManager.LoadScene(loadScene);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
