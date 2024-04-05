using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UI_Base : MonoBehaviour
{   
    protected Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();
    public abstract void Init();

    private void Start()
    {
        Init();
    }
    /// <summary>
    /// ������ ���ε� �� ����
    /// </summary>
    /// <typeparam name="T">T ���� ���۳�Ʈ Ÿ��</typeparam>
    /// <param name="type">enum���� Ÿ���� �����ϴ� Ű��</param>
    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);

        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
                objects[i] = Util.FindChild(gameObject, names[i], true);
            else
                objects[i] = Util.FindChild<T>(gameObject, names[i], true);
        }
    }
    /// <summary>
    /// ���ε��Ǿ��ִ� ������ �ε������´� ������ ������ �´�
    /// </summary>
    /// <typeparam name="T">���۳�Ʈ</typeparam>
    /// <param name="idx">enum�� �ε�����ȣ</param>
    /// <returns></returns>
    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_objects.TryGetValue(typeof(T), out objects) == false)
            return null;

        return objects[idx] as T;
    }

    protected GameObject GetObject(int idx) { return Get<GameObject>(idx); }
    protected TMP_Text GetTMP(int idx) { return Get<TMP_Text>(idx); }
    protected Text GetText(int idx) { return Get<Text>(idx); }
    protected Button GetButton(int idx) { return Get<Button>(idx); }
    protected Image GetImage(int idx) { return Get<Image>(idx); }
    protected Slider GetSlider(int idx) { return Get<Slider>(idx); }
    protected Toggle GetToggle(int idx) { return Get<Toggle>(idx); }
    protected Transform GetTransform(int idx) { return Get<Transform>(idx); }
    protected RectTransform GetRectTransform(int idx) { return Get<RectTransform>(idx); }

    /// <summary>
    /// BindEvent�߰�
    /// </summary>
    /// <param name="go">Event�� �־��� ������Ʈ</param>
    /// <param name="action">UI_EventHandler�� ���� Event���� ������ ����</param>
    /// <param name="type">UI Event����</param>
    public static void BindEvent(GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_EventHandler evt = Util.GetOrAddComponent<UI_EventHandler>(go);

        switch (type)
        {
            case Define.UIEvent.Click:
                evt.OnClickHandler -= action;
                evt.OnClickHandler += action;
                break;
            case Define.UIEvent.Drag:
                evt.OnDragHandler -= action;
                evt.OnDragHandler += action;
                break;
        }
    }
}