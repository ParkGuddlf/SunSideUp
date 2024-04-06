using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stage Data", menuName = "Scriptable Object/Stage Data", order = int.MaxValue)]
public class StageObjectInfo : ScriptableObject
{
    [SerializeField]
    private string StageNum;
    [SerializeField]
    private Sprite StageSprite;
}