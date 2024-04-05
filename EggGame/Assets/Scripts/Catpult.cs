using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Catpult : MonoBehaviour
{
    public float rotationSpeed; // ȸ�� �ӵ�

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (EulerToQuternion() >= -10 && Input.touchCount <= 0)
        {
            rotationSpeed = -40;
        }
        else if(EulerToQuternion() <= -10 && Input.touchCount <= 0)
        {
            rotationSpeed = 0;
        }

        rb.angularVelocity = rotationSpeed;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Stationary)
            {
                if (EulerToQuternion() <= 1)
                {
                    rotationSpeed = 150;
                }
                else
                {
                    rotationSpeed = 0;
                }
            }
        }
            /* if (Input.touchCount > 0)
             {
                 Touch touch = Input.GetTouch(0);
                 if (touch.phase == TouchPhase.Stationary)
                 {
                     if (EulerToQuternion() >= -20)
                     {
                         rotationSpeed = -20;
                     }
                     else
                     {
                         rotationSpeed = 0;
                     }
                 }
                 if (touch.phase == TouchPhase.Ended)
                 {
                     {
                         rotationSpeed = -20;
                     }
                 }
             }*/
        }

    int EulerToQuternion()
    {
        var zAngle = transform.rotation.eulerAngles.z;
        if (zAngle > 180f)
            zAngle -= 360f;

        return (int)zAngle;
    }

}
