using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEditor;
using Unity.VisualScripting;

public class InventoryHandler : MonoBehaviour
{
    public Image deselectedImg;
    public Image selectedImg;
    // Start is called before the first frame update
    public GameObject coinSprite;
    public GameObject carSprite;
    SubDisplay subDisplayCoins;
    SubDisplay subDisplayCars;
    void Start()
    {
        subDisplayCoins = coinSprite.GetComponent<SubDisplay>();
        subDisplayCars = carSprite.GetComponent<SubDisplay>();
    }
    public void showPanel(InventoryItemSO[] InventoryItemSO, GameObject[] InventoryPanelsOO, InventoryTemplate[] InventoryTemplate, string specification){
         for(int i = 0; i< InventoryItemSO.Length; i++){
            if(PlayerPrefs.GetInt("Skin" + specification + i.ToString()) == 1){
                InventoryPanelsOO[i].SetActive(true);
            }
            else{
                 InventoryPanelsOO[i].SetActive(false);
            }
            LoadPanels(InventoryItemSO,InventoryTemplate);
        }
        int Nr = PlayerPrefs.GetInt("Selected" + specification);
        InventoryPanelsOO[Nr].GetComponent<Button>().image.color = Color.blue;
    }

    public void LoadPanels(InventoryItemSO[] InventoryItemSO, InventoryTemplate[] InventoryPanels){
        for(int i = 0; i < InventoryItemSO.Length; i++){
            InventoryPanels[i].title.text = InventoryItemSO[i].title;
           // InventoryPanels[i].sprite = InventoryItemSO[i].sprite; 
        }
    }
    public void select(int btnNr, string specification,GameObject[] InventoryPanelsOO)
    { 
        //change color of selected Inventory field
        int deselect = PlayerPrefs.GetInt("Selected"+ specification);
        InventoryPanelsOO[deselect].GetComponent<Button>().image.color = Color.white;
        PlayerPrefs.SetInt("Selected" + specification, btnNr);
        InventoryPanelsOO[btnNr].GetComponent<Button>().image.color = Color.blue;
        switch(specification){
            case "Coins":
                subDisplayCoins.Start();
                break;
            case "Cars":
                subDisplayCars.Start();
                break;
        }
    }
}
