using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basketball_HoopCtrl1 : MonoBehaviour
{
    public float hoopSpeed;
    private float z = 4f;
    public float y;
    private Rigidbody rb;
    public GameObject hand, left, right, ball;
    public GameObject tutorialPanel, gameManager;
    public Vector3 xMin, xMax, yMin, yMax;
    public float birim;
    private int _counts;

    private void Start()
    {
        xMin = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        yMin = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        xMax = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0));
        yMax = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height));

        birim = ((yMin.y * -1) + yMax.y) / 7;
        y = yMin.y + (birim * 2);

        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        move();

        if(Basketball_ScoreCtrl.score == 10)
        {
            y = yMin.y + birim * 2.5f;
        }

        else if (Basketball_ScoreCtrl.score == 20)
        {
            y = yMin.y + birim * 3;
        }

        else if (Basketball_ScoreCtrl.score == 30)
        {
            y = yMin.y + birim * 3.5f;
        }

        else if (Basketball_ScoreCtrl.score == 40)
        {
            y = yMin.y + birim * 4f;
        }

        else if (Basketball_ScoreCtrl.score == 50)
        {
            y = yMin.y + birim * 4.5f;
        }
    }

    private void move()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, y, z));
                transform.position = new Vector3(transform.position.x, y, transform.position.z);
                //Basketball_BallCtrl.hoop = true;
                /*gameManager.GetComponent<Basketball_BallCtrl>().enabled = true;
                hand.SetActive(false);
                left.SetActive(false);
                right.SetActive(false);
                GetComponent<Animator>().enabled = false;*/
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ball1(Clone)")
        {
            _counts++;
        }

        if (other.gameObject.name == "Ball_Tutorial")
        {
            hand.SetActive(true);
            left.SetActive(true);
            right.SetActive(true);
            GetComponent<Animator>().enabled = true;
        }

        if (_counts >= 3)
        {
            tutorialPanel.SetActive(true);
            Destroy(gameObject);
            Basketball_Health.createBall = false;
        }
    }
}

