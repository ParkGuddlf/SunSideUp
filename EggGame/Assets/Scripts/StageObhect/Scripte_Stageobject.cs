using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Scripte_Stageobject : Stage_Info
{
    Rigidbody2D rigi2D;
    [SerializeField]
    private bool isColliding;
    [SerializeField]
    private float collisionTime = 0f; // ��� �ð�
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    bool issound;

    public GameObject currentEgg;
    private void Start()
    {
        rigi2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        MainCanvas.Instance.stageInfoText.text = stageObjectInfo.stageinfoText;
    }

    private void FixedUpdate()
    {
        if (isClear)
        {
            rigi2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    private void Update()
    {
        if (HasCollidedForThreshold())
        {
            CHECK_SUCCESS(currentEgg);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!issound)
            StartCoroutine(HitSoundCo());
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // �ٸ� Collider�� �������� ��
        if (collision.gameObject.layer == LayerMask.NameToLayer("Egg"))
        {
            isColliding = true; // ���� ���·� ����
            collisionTime = Time.time; // ���� ���� �ð� ���
            currentEgg = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // ������ ������ ��
        if (collision.gameObject.layer == LayerMask.NameToLayer("Egg"))
        {
            isColliding = false; // ���� ���� ���·� ����
            collisionTime = 0f; // ���� �ð� �ʱ�ȭ
            currentEgg = null;
        }
    }
    bool HasCollidedForThreshold()
    {
        // N�� �̻� �����ߴ��� Ȯ��
        return isColliding && (Time.time - collisionTime) >= 3;
    }

    IEnumerator HitSoundCo()
    {        
        issound = true;
        AudioClip asd = Managers.Resource.Load<AudioClip>($"Sounds/thump{3}");
        audioSource.clip = asd;
        audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        issound = false;
    }
}
