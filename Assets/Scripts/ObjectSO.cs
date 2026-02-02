using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PotionItem", menuName ="Items/Item Data")]
public class ObjectSO : ScriptableObject
{
    public string Name;
    [Tooltip("1 for good, 2 for bad, 3 for powerup")]
    [Range(1,3)] public int Type;//good, bad, powerup
    public GameObject Prefab;
}
