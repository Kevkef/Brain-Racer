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
    SpriteRenderer spriteRenderer;
    AudioManager audioManager;
    public AudioClip[] audioClips;
    void OnEnable()
    {
        audioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();
        changeLayer(coinSprite, 0);
        changeLayer(carSprite, 0);
        subDisplayCoins = coinSprite.GetComponent<SubDisplay>();
        subDisplayCars = carSprite.GetComponent<SubDisplay>();
    }
    public void showPanel(InventoryItemSO[] InventoryItemSO, GameObject[] InventoryPanelsOO, InventoryTemplate[] InventoryTemplate, string specification){
         for(int i = 0; i< InventoryItemSO.Length; i++){
            if(PlayerPrefs.GetInt(specification + i.ToString()) == 1){
                InventoryPanelsOO[i].SetActive(true);
            }
            else{
                 InventoryPanelsOO[i].SetActive(false);
            }
            LoadPanels(InventoryItemSO,InventoryTemplate);
        }
        int Nr = PlayerPrefs.GetInt("Selected" + specification);
        InventoryPanelsOO[Nr].GetComponent<Button>().image.color = Color.yellow;
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
        if(specification != "Minigames"){
            int deselect = PlayerPrefs.GetInt("Selected"+ specification);
            InventoryPanelsOO[deselect].GetComponent<Button>().image.color = Color.white;
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
            Debug.Log("TestingTestingtesting");
            audioManager.PauseMusic();
            audioManager.StartSpezificMusic(audioClips[btnNr]);
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
        changeLayer(coinSprite, 1);
        changeLayer(carSprite, 1);
    }
    private void changeLayer(GameObject gameObject, int position){
        spriteRenderer =  gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = position;
    }
}
