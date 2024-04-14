using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Egg : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody2;

    public Transform eggCenterTr;

    bool isSetting;
    private void OnEnable()
    {
        StartCoroutine(movePoint());
    }
    IEnumerator movePoint()
    {
        var asd = GetComponent<Rigidbody2D>();
        var targetPos = new Vector3(-5, 3, 0);
        while (true)
        {
            Vector2 direction = (targetPos- transform.position).normalized;
            float distance = Vector2.Distance(transform.position, targetPos);
            float currentSpeed = Mathf.Clamp(8 * (distance / 10), 0, 5);
            asd.velocity = direction * currentSpeed;
            if (distance < 0.1f)
            {
                isSetting=true;
                break;
            }
            yield return null;
        }
    }
    private void OnDisable()
    {
        isSetting=false;
        transform.position = new Vector3(-15, 3, 0);
    }

    private void Update()
    {
        if (!GameManager.Instance.isStart || !isSetting)
            return;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
                rigidbody2.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
