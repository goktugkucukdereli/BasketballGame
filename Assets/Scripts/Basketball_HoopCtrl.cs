using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Basketball_HoopCtrl : MonoBehaviour, IDragHandler
{
    public float hoopSpeed;
    private float z = 4f;
    public float y;
    private Rigidbody rb;
    public Vector3 xMin, xMax, yMin, yMax;
    public float birim;
    

    Vector2 _screenBound;
    float _objWidth;

    private void Start()
    {
        xMin = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        yMin = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        xMax = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0));
        yMax = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height));

        birim = ((yMin.y * -1) + yMax.y) / 7;
        y = yMin.y + (birim * 2);

        rb = GetComponent<Rigidbody>();

        _screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        _objWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    void FixedUpdate()
    {
      

        //move();

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
            y = yMin.y + birim * 4;
        }

        else if (Basketball_ScoreCtrl.score == 50)
        {
            y = yMin.y + birim * 4.5f;
        }


        Vector2 _viewPoint;
        Vector2 _newPos;
        _viewPoint.x = _screenBound.x + _objWidth;
        _newPos.x = _screenBound.x ;

        if ((transform.position.x >= _viewPoint.x))
        {
            transform.position = new Vector3(-_newPos.x, transform.position.y, transform.position.z);
        }
        else if ((transform.position.x <= -_viewPoint.x))
        {
            transform.position = new Vector3(_newPos.x, transform.position.y, transform.position.z);
        }
    }

    /*private void move()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * hoopSpeed, y, transform.position.z);
                Basketball_BallCtrl.hoop = true;
            }
        }
    }*/

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pointerPos = Camera.main.ScreenToWorldPoint(eventData.position); 
        Debug.Log(new Vector3(pointerPos.x,transform.position.y,transform.position.z));
        //Debug.Log(eventData.delta);
        transform.position =  new Vector3(pointerPos.x,transform.position.y,transform.position.z);
    }
}

