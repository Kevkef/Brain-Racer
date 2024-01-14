using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting.FullSerializer;
using Unity.VisualScripting;
using System;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class SaveHandler : MonoBehaviour
{
    public GameObject[] savePanelsOO; 
    public SaveTemplate[] saveTemplate;
    public GameObject noSaveSlotPanel;
    // Start is called before the first frame update
    EEGData eegData;
    Boolean noSaveSlot;
    void Start()
    {
        ShowPanel();
    }

    public SaveSlots GetSaveSlots(){
        SaveData saveData = GameObject.Find("SaveManager").GetComponent<SaveData>();
        SaveSlots saveSlots = saveData.LoadFromJson();
        return saveSlots;
    }
  
    public void ShowPanel(){    
        noSaveSlot = true;
        SaveSlots saveSlots = GetSaveSlots();
        for(int i = 0; i< 10; i++){
            if (saveSlots.slotData[i].title == "")
            {
                savePanelsOO[i].SetActive(false);
            }
            else{
                noSaveSlot = false;
                savePanelsOO[i].SetActive(true);
                saveTemplate[i].title.text = saveSlots.slotData[i].title;
                saveTemplate[i].world.text = saveSlots.slotData[i].world;
            }
        }
        if(noSaveSlot == true){
            noSaveSlotPanel.SetActive(true);
        }
        else{
             noSaveSlotPanel.SetActive(false);
        }
    }
    public void loadSave(int i){
        //load the spezified Save
        SaveSlots saveSlots = GetSaveSlots();
        SaveManager saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        saveManager.setSlotDataScene(saveSlots.slotData[i]); //Game Scene will be requestig data from slotDataScene
        eegData = GameObject.Find("EEGManager").GetComponent<EEGData>();
        SaveData saveData = GameObject.Find("SaveManager").GetComponent<SaveData>();
        saveData.saveSlotNumber = i;
        try{
            eegData.Disconnect();
        }
        catch{
            Debug.Log("Not Disconnected");
       }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void deleteSave(int i)
    {
        //Sets save to default values
        SaveData saveData = GameObject.Find("SaveManager").GetComponent<SaveData>();
        saveData.deleteFromSaveSlots(i);
        PlayerPrefs.SetInt("AvalibleSlots", PlayerPrefs.GetInt("AvalibleSlots")+1);
        ShowPanel();
    }

}
