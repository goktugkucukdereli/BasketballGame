using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Pota
{
    public class Score : MonoBehaviour
    {
        public Text scoreText;
        [FormerlySerializedAs("highscoreText")] public Text highScoreText;
        public static int score;
        [FormerlySerializedAs("highscore")] public int highScore;
        
        void Start()
        {
            score = 0;
            highScore = PlayerPrefs.GetInt("basketball_HighScore");
        }
        
        void FixedUpdate()
        {
            scoreText.text = score.ToString();
            highScoreText.text = highScore.ToString();
            
            if(score > highScore && HoopController.isTutorial == false)
            {
                highScore = score;
                PlayerPrefs.SetInt("basketball_HighScore", score);
            }
        }
        
        public static void AddScore(GameObject ball)
        {
            if (ball.name == "Ball1(Clone)") 
            {
                if (!HoopController.isTutorial)
                {
                    Debug.Log("SCORE!");
                    score++;
                    PlayerPrefs.SetInt("basketball_Score", score);
                }
                else
                {
                    Debug.Log("Tutorial Score!");
                    score++;
                }

                
                Basketball_AudioManager.aManager.ScoreVoice();
                Basketball_AudioManager.aManager.BasketVoice();
                
            }
            
        }
    }
}