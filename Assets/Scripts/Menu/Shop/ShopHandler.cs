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
    public int points;
    public TMP_Text costCoins;
    public TMP_Text costPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        points = PlayerPrefs.GetInt("Points");
    }
    public void ShowPanel(ShopItemSO[] shopItemSO, GameObject[] shopPanelsOO, ShopTemplate[] shopTemplate, string specification, string currency){
         for(int i = 0; i< shopItemSO.Length; i++){
            if(PlayerPrefs.GetInt(specification + i.ToString()) == 1){
                shopPanelsOO[i].SetActive(false);
            }
            else{
                 shopPanelsOO[i].SetActive(true);
            }
            LoadPanels(shopItemSO,shopTemplate,currency);
            switch(currency){
                case "Coins":
                    UpdateCoins();
                    break;
                case "Points":
                    UpdatePoints();
                    break;
            }
        }
    }
    public void AddCoins(){
        coins++;
        PlayerPrefs.SetInt("Coins", coins);
        UpdateCoins();
    }
     public void AddPoints(){
        points++;
        PlayerPrefs.SetInt("Points", points);
        UpdatePoints();
    }
    public void UpdateCoins(){
        costCoins.text = "Coins: " + PlayerPrefs.GetInt("Coins");
    }
    public void UpdatePoints(){
        costPoints.text = "Points: " + PlayerPrefs.GetInt("Points");
    }
    public void PurchaseCoins(int btnNr, ShopItemSO[] shopItemSO, String submenu){
        if(coins >= shopItemSO[btnNr].baseCost){
            coins = coins - shopItemSO[btnNr].baseCost;
            PlayerPrefs.SetInt("Coins", coins);
            PlayerPrefs.SetInt(submenu+ btnNr.ToString(), 1);
            UpdateCoins();
        }
    }
    public void PurchasePoints(int btnNr, ShopItemSO[] shopItemSO, String submenu){
        if(points >= shopItemSO[btnNr].baseCost){
            points = points - shopItemSO[btnNr].baseCost;
            PlayerPrefs.SetInt("Points", points);
            PlayerPrefs.SetInt(submenu+ btnNr.ToString(), 1);
            UpdatePoints();
        }
    }
    public void CheckPurchaseable(ShopItemSO[] shopItemSO, Button[] myPurchaseBtns, String currency){
        for(int i = 0; i < shopItemSO.Length; i++)
            {
                if(shopItemSO[i].baseCost <= PlayerPrefs.GetInt(currency)){
                    myPurchaseBtns[i].interactable = true;
                }
                else{
                    myPurchaseBtns[i].interactable = false;
                }
            }
    }

    public void LoadPanels(ShopItemSO[] shopItemSO, ShopTemplate[] shopPanels, string currency){
        for(int i = 0; i < shopItemSO.Length; i++){
            shopPanels[i].title.text = shopItemSO[i].title;
            shopPanels[i].description.text = shopItemSO[i].description; 
            shopPanels[i].sprite.GetComponent<SpriteRenderer>().sprite = shopItemSO[i].look;
            shopPanels[i].cost.text = currency + ": " + shopItemSO[i].baseCost.ToString();  
        }
    }
}
