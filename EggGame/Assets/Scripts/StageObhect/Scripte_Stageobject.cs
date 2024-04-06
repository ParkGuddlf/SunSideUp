using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripte_Stageobject : Stage_Info
{
    Rigidbody2D rigi2D;
    [SerializeField]
    private bool isColliding;
    [SerializeField]
    private float collisionTime = 0f; // 경과 시간

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
        // 다른 Collider와 접촉했을 때
        if (collision.gameObject.layer == LayerMask.NameToLayer("Egg"))
        {
            isColliding = true; // 접촉 상태로 설정
            collisionTime = Time.time; // 접촉 시작 시간 기록
            adsasd = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // 접촉이 끝났을 때
        if (collision.gameObject.layer == LayerMask.NameToLayer("Egg"))
        {
            isColliding = false; // 접촉 종료 상태로 설정
            collisionTime = 0f; // 접촉 시간 초기화
            adsasd = null;
        }
    }
    bool HasCollidedForThreshold()
    {
        // N초 이상 접촉했는지 확인
        return isColliding && (Time.time - collisionTime) >= 3;
    }

}
