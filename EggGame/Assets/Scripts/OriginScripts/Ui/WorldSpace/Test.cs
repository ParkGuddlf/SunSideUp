using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public void TestButton()
    {
        if (gameObject.GetComponentInChildren<UI_Button>() == null)
            Managers.UI.ShowPopupUI<UI_Button>("UI_Button");
    }
    //���ðڽ��ϱ� ������
}
