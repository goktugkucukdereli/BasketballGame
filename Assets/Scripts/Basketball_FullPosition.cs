using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball_FullPosition : MonoBehaviour
{
    public static Vector3 FullPos;

    void Update()
    {
        FullPos = transform.position;
    }
}
