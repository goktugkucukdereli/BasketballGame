using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball_BallMove : MonoBehaviour
{
    Rigidbody rb;
    public float ballSpeed;
    public float angularSpeed;
    public static bool isBall = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0f, -transform.position.y * ballSpeed, 0f);
        rb.angularVelocity = Random.insideUnitSphere * angularSpeed;
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
