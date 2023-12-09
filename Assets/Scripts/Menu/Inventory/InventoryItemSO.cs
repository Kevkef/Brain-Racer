using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[CreateAssetMenu(fileName="InventoryMenu", menuName = "Scriptable Objects/New Inventory Item", order= 1)]
public class InventoryItemSO : ScriptableObject
{
     public Image sprite;
     public string title;
}
