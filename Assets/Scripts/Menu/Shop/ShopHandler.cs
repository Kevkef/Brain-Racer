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
    public GameObject boughtEverything;
    public AudioManager audioManager;
    public AudioClip audioClip;
    int noActive;
    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        points = PlayerPrefs.GetInt("Points");
    }
    public void ShowPanel(ShopItemSO[] shopItemSO, GameObject[] shopPanelsOO, ShopTemplate[] shopTemplate, string specification, string currency){
        noActive = 0;
         for(int i = 0; i< shopItemSO.Length; i++){
            if(PlayerPrefs.GetInt(specification + i.ToString()) == 1){
                shopPanelsOO[i].SetActive(false);
            }
            else{
                noActive++;
                shopPanelsOO[i].SetActive(true);
            }
            if(noActive == 0){
                boughtEverything.SetActive(true);
            }
            else{
                boughtEverything.SetActive(false);
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
            audioManager.PlaySFX(audioClip);
        }
    }
    public void PurchasePoints(int btnNr, ShopItemSO[] shopItemSO, String submenu){
        if(points >= shopItemSO[btnNr].baseCost){
            points = points - shopItemSO[btnNr].baseCost;
            PlayerPrefs.SetInt("Points", points);
            PlayerPrefs.SetInt(submenu+ btnNr.ToString(), 1);
            UpdatePoints();
            audioManager.PlaySFX(audioClip);
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
            try{
            shopPanels[i].sprite.GetComponent<SpriteRenderer>().sprite = shopItemSO[i].look;
            }
            catch{
                //Audio Component does not have a Sprite so thatline should not activate then
            }
            shopPanels[i].cost.text = currency + ": " + shopItemSO[i].baseCost.ToString();  
        }
    }
}
