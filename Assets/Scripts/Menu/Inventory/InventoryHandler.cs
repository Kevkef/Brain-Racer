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
    public AudioClip audioClip;
    public AudioClip selectedAudioClip;
    Color lightOrange = new Color(255,245, 203, 255);
    void OnEnable()
    {
        audioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();
       // changeLayer(coinSprite, 0);
        changeLayer(carSprite, 0);
        subDisplayCoins = coinSprite.GetComponent<SubDisplay>();
        subDisplayCars = carSprite.GetComponent<SubDisplay>();
        audioManager.PlaySFX(audioClip);
    }
    public void showPanel(InventoryItemSO[] InventoryItemSO, GameObject[] InventoryPanelsOO, InventoryTemplate[] InventoryTemplate, string specification){
         for(int i = 0; i< InventoryItemSO.Length; i++){
            if(specification != "Minigames"){
            if(PlayerPrefs.GetInt(specification + (i-1).ToString()) == 1){
                InventoryPanelsOO[i].SetActive(true);
            }
            else{
                 InventoryPanelsOO[i].SetActive(false);
            }
            }
            else {
                if(PlayerPrefs.GetInt(specification + (i).ToString()) == 1){
                    InventoryPanelsOO[i].SetActive(true);
                }
                else{
                    InventoryPanelsOO[i].SetActive(false);
                }
            }
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
            audioManager.PlaySFX(selectedAudioClip);
            try{
            int deselect = PlayerPrefs.GetInt("Selected"+ specification);
            InventoryPanelsOO[deselect].GetComponent<Button>().image.color = lightOrange;
            }
            catch{}
            PlayerPrefs.SetInt("Selected" + specification, btnNr);
            InventoryPanelsOO[btnNr].GetComponent<Button>().image.color = Color.yellow;
        }
        else{
            if(InventoryPanelsOO[btnNr].GetComponent<Button>().image.color == Color.yellow)
            {
                InventoryPanelsOO[btnNr].GetComponent<Button>().image.color = lightOrange;
                PlayerPrefs.SetInt("Mathmode",0);
            }
            else{
                PlayerPrefs.SetInt("Mathmode",1);
                audioManager.PlaySFX(selectedAudioClip);
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
        if(gameObject != carSprite){
            image =  gameObject.GetComponent<Image>();
            if(position == 1){
                image.color = new Color(255,255,255,255);
             }
            else {
                image.color = new Color(255,255,255,0);
            }
        }
        else {
            SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
            if(position == 1){
                sprite.color = new Color(255,255,255,255);
             }
            else {
                sprite.color = new Color(255,255,255,0);
            }
        }

        
    }
}
