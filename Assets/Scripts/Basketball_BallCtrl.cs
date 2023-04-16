using System.Collections;
using System.Collections.Generic;
using Pota;
using UnityEngine;

public class Basketball_BallCtrl : MonoBehaviour
{
    public Vector3 ballRandomPos;
    public GameObject ball;
    public static bool hoop = false;
    public float startTime;
    public float createTime;
    public static int count = 0;
    void Start()
    {
        InvokeRepeating("ballCreate", startTime, createTime);
    }

    private void ballCreate()
    {
        if (Basketball_Health.createBall == true)
        {
            Vector3 vec = new Vector3(Random.Range(-ballRandomPos.x, ballRandomPos.x), ballRandomPos.y, -6f);
            Instantiate(ball, vec, Quaternion.identity);
            if(HoopController.isTutorial)
                count++;
        }
    }
}
