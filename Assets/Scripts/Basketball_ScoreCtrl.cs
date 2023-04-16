using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basketball_ScoreCtrl : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;
    public static int score;
    public int highscore;
    public GameObject torus;
    private Animator anim;
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        highscore = PlayerPrefs.GetInt("basketball_HighScore");
        anim = torus.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        scoreText.text = score.ToString();

        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("basketball_HighScore", score);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball1(Clone)") 
        {
            score++;
            Basketball_AudioManager.aManager.ScoreVoice();
            Basketball_AudioManager.aManager.BasketVoice();
            PlayerPrefs.SetInt("basketball_Score", score);
            anim.SetTrigger("torus2");
            StartCoroutine(DestroyEnemy());
            Basketball_BallMove.isBall = true;
        }

        if (other.gameObject.name == "Ball_Tutorial")
        {
            Basketball_AudioManager.aManager.BasketVoice();
            anim.SetTrigger("torus2");
            Basketball_BallMove.isBall = true;
        }
    }

    IEnumerator DestroyEnemy() 
    {
        yield return new WaitForSecondsRealtime(1f);
    }
}
