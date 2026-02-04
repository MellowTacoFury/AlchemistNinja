using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_SO", menuName = "Item_SO", order = 0)]
public class Item_SO : ScriptableObject {
    public string ItemName = "Default_Item_Name";
    [Tooltip("1 is good, 2, is bad, 3 is powerups")]
    [Range(1, 3)]
    public int ItemType;
}