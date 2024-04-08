using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stage_Info : MonoBehaviour
{
    [SerializeField]
    public StageObjectInfo stageObjectInfo;

    [SerializeField]
    SpriteRenderer SpriteRenderer;

    [SerializeField]
    public bool isClear;
    protected void CHECK_SUCCESS(GameObject eggObject)
    {
        if (isClear == false)
        {
            if (eggObject.layer != LayerMask.NameToLayer("Egg"))
            {
                return;
            }

            isClear = true;
            Managers.Resource.Instantiate("ClearCanvas",null,1);
            Debug.Log("¼º°ø");
        }
    }
}
