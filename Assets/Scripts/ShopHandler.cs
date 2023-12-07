using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting.FullSerializer;
using Unity.VisualScripting;


public class ShopHandler : MonoBehaviour
{
    public int coins;
    public TMP_Text cost;
    public ShopItemSO[] shopItemSO;
    public GameObject[] shopPanelsOO; // the same as shopPanels.gameObject
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;

    
    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        for(int i = 0; i< shopItemSO.Length; i++){
           shopPanelsOO[i].SetActive(true);
            LoadPanels();
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
        CheckPurchaseable();
    }
    public void Purchase(int btnNr){
        if(coins >= shopItemSO[btnNr].baseCost){
            coins = coins - shopItemSO[btnNr].baseCost;
            PlayerPrefs.SetInt("Coins", coins);
            UpdateCoins();
        }
    }

    public void CheckPurchaseable(){
        for(int i = 0; i < shopItemSO.Length; i++)
            {
                if(shopItemSO[i].baseCost <= coins){
                    myPurchaseBtns[i].interactable = true;
                }
                else{
                    myPurchaseBtns[i].interactable = false;
                }
            }
    }

    public void LoadPanels(){
        for(int i = 0; i < shopItemSO.Length; i++){
            shopPanels[i].title.text = shopItemSO[i].title;
            shopPanels[i].description.text = shopItemSO[i].description; 
            shopPanels[i].cost.text = "Coins: " + shopItemSO[i].baseCost.ToString();  
        }
    }
}
