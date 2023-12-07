using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting.FullSerializer;
using Unity.VisualScripting;
using System;


public class ShopHandler : MonoBehaviour
{
    public int coins;
    public TMP_Text cost;
    
    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
    }
    public void showPanel(ShopItemSO[] shopItemSO, GameObject[] shopPanelsOO, ShopTemplate[] shopTemplate, string specification){
         for(int i = 0; i< shopItemSO.Length; i++){
            if(PlayerPrefs.GetInt("Skin" + specification + i.ToString()) == 1){
                shopPanelsOO[i].SetActive(false);
            }
            else{
                 shopPanelsOO[i].SetActive(true);
            }
            LoadPanels(shopItemSO,shopTemplate);
            UpdateCoins();
        }
    }
    public void AddCoins(){
        coins++;
        PlayerPrefs.SetInt("Coins", coins);
        UpdateCoins();
    }
    private void UpdateCoins(){
        cost.text = "Coins:" + PlayerPrefs.GetInt("Coins");
    }
    public void Purchase(int btnNr, ShopItemSO[] shopItemSO, String submenu){
        if(coins >= shopItemSO[btnNr].baseCost){
            coins = coins - shopItemSO[btnNr].baseCost;
            PlayerPrefs.SetInt("Coins", coins);
            PlayerPrefs.SetInt("Skin" + submenu+ btnNr.ToString(), 1);
            UpdateCoins();
        }
    }

    public void CheckPurchaseable(ShopItemSO[] shopItemSO, Button[] myPurchaseBtns){
        for(int i = 0; i < shopItemSO.Length; i++)
            {
                if(shopItemSO[i].baseCost <= PlayerPrefs.GetInt("Coins")){
                    myPurchaseBtns[i].interactable = true;
                }
                else{
                    myPurchaseBtns[i].interactable = false;
                }
            }
    }

    public void LoadPanels(ShopItemSO[] shopItemSO, ShopTemplate[] shopPanels){
        for(int i = 0; i < shopItemSO.Length; i++){
            shopPanels[i].title.text = shopItemSO[i].title;
            shopPanels[i].description.text = shopItemSO[i].description; 
            shopPanels[i].cost.text = "Coins: " + shopItemSO[i].baseCost.ToString();  
        }
    }}
