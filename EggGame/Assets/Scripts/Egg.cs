using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody2;

    public Transform eggCenterTr;

    private void Update()
    {
        if (!GameManager.Instance.isStart)
            return;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
                rigidbody2.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
