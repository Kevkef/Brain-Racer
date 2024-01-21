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
    Image deselectedImg;
    Image selectedImg;
    // Start is called before the first frame update
    public GameObject coinSprite;
    public GameObject carSprite;
    SubDisplay subDisplayCoins;
    SubDisplay subDisplayCars;
    Image image;
    AudioManager audioManager;
    void OnEnable()
    {
        audioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();
       // changeLayer(coinSprite, 0);
        changeLayer(carSprite, 0);
        subDisplayCoins = coinSprite.GetComponent<SubDisplay>();
        subDisplayCars = carSprite.GetComponent<SubDisplay>();
    }
    public void showPanel(InventoryItemSO[] InventoryItemSO, GameObject[] InventoryPanelsOO, InventoryTemplate[] InventoryTemplate, string specification){
         for(int i = 0; i< InventoryItemSO.Length; i++){
            if(PlayerPrefs.GetInt(specification + (i-1).ToString()) == 1){
                InventoryPanelsOO[i].SetActive(true);
            }
            else{
                 InventoryPanelsOO[i].SetActive(false);
            }
            Debug.Log(specification + (i-1).ToString());
            Debug.Log(PlayerPrefs.GetInt(specification + (i-1).ToString()));
            LoadPanels(InventoryItemSO,InventoryTemplate);
        }
        int Nr = PlayerPrefs.GetInt("Selected" + specification);
        InventoryPanelsOO[Nr].GetComponent<Button>().image.color = Color.yellow;
    }
    

    public void LoadPanels(InventoryItemSO[] InventoryItemSO, InventoryTemplate[] InventoryPanels){
        for(int i = 0; i < InventoryItemSO.Length; i++){
            InventoryPanels[i].title.text = InventoryItemSO[i].title;
            InventoryPanels[i].sprite.GetComponent<SpriteRenderer>().sprite = InventoryItemSO[i].sprite; 
        }
    }

    public void select(int btnNr, string specification,GameObject[] InventoryPanelsOO)
    { 
        //change color of selected Inventory field 
        if(specification != "Minigames"){
            try{
            int deselect = PlayerPrefs.GetInt("Selected"+ specification);
            InventoryPanelsOO[deselect].GetComponent<Button>().image.color = Color.white;
            }
            catch{}
            PlayerPrefs.SetInt("Selected" + specification, btnNr);
            InventoryPanelsOO[btnNr].GetComponent<Button>().image.color = Color.yellow;
        }
        else{
            if(InventoryPanelsOO[btnNr].GetComponent<Button>().image.color == Color.yellow)
            {
                InventoryPanelsOO[btnNr].GetComponent<Button>().image.color = Color.white;
                 PlayerPrefs.SetInt(specification +btnNr,0);
            }
            else{
                 PlayerPrefs.SetInt(specification +btnNr,1);
                InventoryPanelsOO[btnNr].GetComponent<Button>().image.color = Color.yellow;
            }
        }
        if(specification =="Audio"){
            audioManager.PauseMusic();
            audioManager.StartSpezificMusic();
        }
        switch(specification){
            case "SkinCoins":
                subDisplayCoins.Start();
                break;
            case "SkinCars":
                subDisplayCars.Start();
                break;
        }
    }
    public void closeInventory(){
        //changeLayer(coinSprite, 1);
        changeLayer(carSprite, 1);
    }
    private void changeLayer(GameObject gameObject, int position){
        image =  gameObject.GetComponent<Image>();
        if(position == 1){
        image.color = new Color(255,255,255,255);
        }
        else {
            image.color = new Color(255,255,255,0);
        }
    }
}
