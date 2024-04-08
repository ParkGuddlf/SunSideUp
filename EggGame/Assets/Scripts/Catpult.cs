using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Catpult : MonoBehaviour
{
    public float rotationSpeed; // 회전 속도

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!GameManager.Instance.isStart)
            return;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Stationary)
            {
                if (EulerToQuternion() <= 1)
                {
                    rotationSpeed = 180;
                }
                else
                {
                    rotationSpeed = 0;
                }
            }
        }
        if (EulerToQuternion() >= -10 && Input.touchCount <= 0)
        {
            rotationSpeed = -40;
        }
        else if (EulerToQuternion() <= -10 && Input.touchCount <= 0)
        {
            rotationSpeed = 0;
        }

        rb.angularVelocity = rotationSpeed;
    }

    int EulerToQuternion()
    {
        var zAngle = transform.rotation.eulerAngles.z;
        if (zAngle > 180f)
            zAngle -= 360f;

        return (int)zAngle;
    }

}
