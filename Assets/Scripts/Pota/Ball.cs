using System;
using UnityEngine;

namespace Pota
{
    public class Ball : MonoBehaviour
    {
        public bool enter,exit=false;
        public bool enterControl,exitControl=false;
        public float ballSpeed;
        public float angularSpeed;
        public static bool isBall = false;
        public bool Count => enter && exit && enterControl && exitControl;

        private void Start()
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0f, -transform.position.y * ballSpeed, 0f);
            rb.angularVelocity = UnityEngine.Random.insideUnitSphere * angularSpeed;
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Torus")
            {
                Basketball_AudioManager.aManager.ContactVoice();
            }

            if(collision.gameObject.name == "Ball1(Clone)")
            {
                Basketball_AudioManager.aManager.CrushVoice();
            }
        }
    }
}