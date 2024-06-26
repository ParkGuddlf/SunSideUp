using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using TMPro;

public class UI_Button : UI_Popup,IPointerEnterHandler
{
    enum Buttons
    {
        PointButton,
    }

    enum Texts
    {
        PointText,        
    }

    enum GameObjects
    {
        TestObject,
    }

    enum Images
    {
        ItemIcon,
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<TMP_Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        GetButton((int)Buttons.PointButton).gameObject.BindEvent(OnButtonClicked);

        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        BindEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
    }


    public void OnButtonClicked(PointerEventData data)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }
    
    public void Close()
    {
        ClosePopupUI();   
    }

}
