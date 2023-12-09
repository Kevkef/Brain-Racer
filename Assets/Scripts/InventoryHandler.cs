using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEditor;

public class InventoryHandler : MonoBehaviour
{
    public Image deselectedImg;
    public Image selectedImg;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void showPanel(InventoryItemSO[] InventoryItemSO, GameObject[] InventoryPanelsOO, InventoryTemplate[] InventoryTemplate, string specification){
         for(int i = 0; i< InventoryItemSO.Length; i++){
            if(PlayerPrefs.GetInt("Skin" + specification + i.ToString()) == 1){
                Debug.Log("test");
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
        int deselect = PlayerPrefs.GetInt("Selected"+ specification);
        InventoryPanelsOO[deselect].GetComponent<Button>().image.color = Color.white;
        PlayerPrefs.SetInt("Selected" + specification, btnNr);
        InventoryPanelsOO[btnNr].GetComponent<Button>().image.color = Color.blue;
    }
    }
