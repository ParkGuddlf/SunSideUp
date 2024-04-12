using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Catpult : MonoBehaviour
{
    public float rotationSpeed; // 회전 속도

    private Rigidbody2D rigi2D;
    private AudioSource audioSource;

    void Start()
    {
        rigi2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        rigi2D.angularVelocity = rotationSpeed;
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
                    rotationSpeed = 150;
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

    }
    [SerializeField]
    int count;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(count == 0)
            audioSource.Play();
        count++;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        count--;
        if(count == 0)
            audioSource.Stop();
    }

    int EulerToQuternion()
    {
        var zAngle = transform.rotation.eulerAngles.z;
        if (zAngle > 180f)
            zAngle -= 360f;

        return (int)zAngle;
    }

}
