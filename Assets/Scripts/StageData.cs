using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="StageData", menuName ="SO/ StageLimit")]
public class StageData : ScriptableObject
{
    [SerializeField] private Vector3 limitMin;
    [SerializeField] private Vector3 limitMax;

    public Vector3 LimitMin => limitMin;
    public Vector3 LimitMax => limitMax;
}
