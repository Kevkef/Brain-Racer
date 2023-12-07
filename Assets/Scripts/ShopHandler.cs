using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting.FullSerializer;

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
        
        for(int i = 0; i< shopItemSO.Length; i++){
           shopPanelsOO[i].SetActive(true);
            cost.text = "Coins:" + coins.ToString();
            LoadPanels();
            CheckPurchaseable();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddCoins(){
        coins++;
        UpdateCoins();
    }
    private void UpdateCoins(){
         cost.text = "Coins:" + coins;
        CheckPurchaseable();
    }
    public void Purchase(int btnNr){
        if(coins >= shopItemSO[btnNr].baseCost){
            coins = coins - shopItemSO[btnNr].baseCost;
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
