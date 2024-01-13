using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName="ShopMenu", menuName = "Scriptable Objects/New Audio Item", order= 1)]
public class ShopAudioSO : ShopItemSO
{
    public AudioClip audioClip;
}