using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class SubHandler : MonoBehaviour
{
    public string specification;
    public string currency;
    public ShopItemSO[] shopItemSkinSO;
    public GameObject[] shopPanelsSkinOO; // the same as shopPanels.gameObject
    public ShopTemplate[] shopPanelsSkin;
    public Button[] myPurchaseSkinBtns;
    ShopHandler shopHandler;

    public void OnEnable()
    {
        shopHandler = GameObject.Find("Shop").GetComponent<ShopHandler>();
        shopHandler.ShowPanel(shopItemSkinSO, shopPanelsSkinOO ,shopPanelsSkin, specification, currency);
        CheckPurchaseable();
        shopHandler.UpdateCoins();
        shopHandler.UpdatePoints();      
    }

    public void CheckPurchaseable(){
        shopHandler.CheckPurchaseable(shopItemSkinSO,myPurchaseSkinBtns, currency);
    }
    public void PurchaseCoins(int btnNr){
        shopHandler.PurchaseCoins(btnNr, shopItemSkinSO, specification);
        shopHandler.ShowPanel(shopItemSkinSO, shopPanelsSkinOO ,shopPanelsSkin, specification, currency);
        CheckPurchaseable();
    }
    public void PurchasePoints(int btnNr){
        shopHandler.PurchasePoints(btnNr, shopItemSkinSO, specification);
        shopHandler.ShowPanel(shopItemSkinSO, shopPanelsSkinOO ,shopPanelsSkin, specification, currency);
        CheckPurchaseable();
    }
}
