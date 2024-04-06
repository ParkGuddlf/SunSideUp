using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripte_Stageobject : Stage_Info
{
    Rigidbody2D rigi2D;
    [SerializeField]
    private bool isColliding;
    [SerializeField]
    private float collisionTime = 0f; // ��� �ð�

    private void Start()
    {
        rigi2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isClear)
        {
            rigi2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    GameObject adsasd;
    private void Update()
    {
        if (HasCollidedForThreshold())
        {
            CHECK_SUCCESS(adsasd);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �ٸ� Collider�� �������� ��
        if (collision.gameObject.layer == LayerMask.NameToLayer("Egg"))
        {
            isColliding = true; // ���� ���·� ����
            collisionTime = Time.time; // ���� ���� �ð� ���
            adsasd = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // ������ ������ ��
        if (collision.gameObject.layer == LayerMask.NameToLayer("Egg"))
        {
            isColliding = false; // ���� ���� ���·� ����
            collisionTime = 0f; // ���� �ð� �ʱ�ȭ
            adsasd = null;
        }
    }
    bool HasCollidedForThreshold()
    {
        // N�� �̻� �����ߴ��� Ȯ��
        return isColliding && (Time.time - collisionTime) >= 3;
    }

}
