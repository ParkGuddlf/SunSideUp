using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "Stage Data", menuName = "Scriptable Object/Stage Data", order = int.MaxValue)]
public class StageObjectInfo : ScriptableObject
{
    [SerializeField]
    [Multiline(3)]
    public string stageinfoText;
}