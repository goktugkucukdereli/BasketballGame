using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Pota
{
    public class HoopController : MonoBehaviour, IDragHandler
    {
        public float xMin, xMax, yMin, yMax;
        public float y;
        [FormerlySerializedAs("verticalSpace")] public float verticalSpace;
        private Camera cam;
        public static bool isTutorial = false;
        public bool tutorialEnabled = false;
        public static bool isFirstTouchMade = false;

        private void Awake()
        {
            isTutorial = tutorialEnabled;
            isFirstTouchMade = !isTutorial;
        }

        private void Start()
        {   
            cam = Camera.main;
            float objWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
            float objHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
            xMin = cam.ScreenToWorldPoint(new Vector2(objWidth, 0)).x;
            yMin = cam.ScreenToWorldPoint(new Vector2(0, objHeight)).y;
            xMax = cam.ScreenToWorldPoint(new Vector2(Screen.width-objWidth, 0)).x;
            yMax = cam.ScreenToWorldPoint(new Vector2(0, Screen.height-objHeight)).y;

            verticalSpace = ((yMin * -1) + yMax) / 7;
            y = yMin + (verticalSpace * 2);

            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
        
        void FixedUpdate()
        {
            
                
            if(Score.score == 10)
            {
                y = yMin + verticalSpace * 2.5f;
            }

            else if (Score.score == 20)
            {
                y = yMin + verticalSpace * 3;
            }

            else if (Score.score == 30)
            {
                y = yMin + verticalSpace * 3.5f;
            }

            else if (Score.score == 40)
            {
                y = yMin + verticalSpace * 4;
            }

            else if (Score.score == 50)
            {
                y = yMin + verticalSpace * 4.5f;
            }

            

        }

        public void OnDrag(PointerEventData eventData)
        {

            if (isTutorial && !isFirstTouchMade)
            {
                isFirstTouchMade = true;
                Basketball_Health.createBall = true;
            }

            Vector2 pointerPos = Camera.main.ScreenToWorldPoint(eventData.position);
            //Debug.Log(new Vector3(pointerPos.x,y,transform.position.z));
            //Debug.Log(eventData.delta);
            transform.position = new Vector3(Mathf.Clamp(pointerPos.x, xMin, xMax), y, transform.position.z);
        }

    }
}