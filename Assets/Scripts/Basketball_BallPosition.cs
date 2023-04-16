using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball_BallPosition : MonoBehaviour
{
    Vector3 fullPos;
    public bool isBall;

    private void Start()
    {
        isBall = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        isBall = true;
    }
    void Update()
    {
        fullPos = Basketball_FullPosition.FullPos;
        if (transform.position.y< fullPos.y && isBall == false)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -8.5f);
        }
    }
}
