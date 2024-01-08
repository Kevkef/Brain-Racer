using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class SubHandler : MonoBehaviour
{
    public string specification;
    public ShopItemSO[] shopItemSkinSO;
    public GameObject[] shopPanelsSkinOO; // the same as shopPanels.gameObject
    public ShopTemplate[] shopPanelsSkin;
    public Button[] myPurchaseSkinBtns;
    ShopHandler shopHandler;

    // Start is called before the first frame update
    void Start()
    {
        shopHandler = GameObject.Find("Shop").GetComponent<ShopHandler>();
        shopHandler.showPanel(shopItemSkinSO, shopPanelsSkinOO ,shopPanelsSkin, specification);
        CheckPurchaseable();      
    }

    public void CheckPurchaseable(){
        shopHandler.CheckPurchaseable(shopItemSkinSO,myPurchaseSkinBtns);
    }
    public void Purchase (int btnNr){
        shopHandler.Purchase(btnNr, shopItemSkinSO, specification);
        shopHandler.showPanel(shopItemSkinSO, shopPanelsSkinOO ,shopPanelsSkin, specification);
    }
}
