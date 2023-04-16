using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Pota
{
    public class BallCheck : MonoBehaviour
    {
        public bool forControl = false;

        private void OnTriggerEnter(Collider ball)
        {
            if (forControl)
                ball.GetComponent<Ball>().enterControl = true;
            else
                ball.GetComponent<Ball>().enter = true;
        }

        private void OnTriggerExit(Collider ball)
        {
            if (forControl)
            {
                Ball ballObject= ball.GetComponent<Ball>();
                ballObject.exitControl = true;
                if (ballObject.Count)
                {
                    
                    Score.AddScore(ball.gameObject);
                    //StartCoroutine(DestroyBall(ball.gameObject));
                }
                    
            }
            else
                ball.GetComponent<Ball>().exit = true;
        }

        private IEnumerator DestroyBall(GameObject ball)
        {
            yield return new WaitForSeconds(1f);
            Destroy(ball);
        }
    }
}