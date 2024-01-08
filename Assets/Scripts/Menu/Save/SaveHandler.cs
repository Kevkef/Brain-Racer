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
    public static SlotData slotDataScene;
    public GameObject[] savePanelsOO; 
    public SaveTemplate[] saveTemplate;
    // Start is called before the first frame update
    void Start()
    {
        ShowPanel();
    }

    public SaveSlots GetSaveSlots(){
        SaveData saveData = GameObject.Find("Save").GetComponent<SaveData>();
        SaveSlots saveSlots = saveData.LoadFromJson();
        return saveSlots;
    }

    public void ShowPanel(){
        SaveSlots saveSlots = GetSaveSlots();
        for(int i = 0; i< 10; i++){
            if (saveSlots.slotData[i].title == "")
            {
                savePanelsOO[i].SetActive(false);
            }
            else{
                 savePanelsOO[i].SetActive(true);
                 saveTemplate[i].title.text = saveSlots.slotData[i].title;
            saveTemplate[i].world.text = saveSlots.slotData[i].world;
            }
        }
    }

    public void loadSave(int i){
        SaveSlots saveSlots = GetSaveSlots();
        slotDataScene = saveSlots.slotData[i];
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void deleteSave(int i)
    {
        SaveData saveData = GameObject.Find("Save").GetComponent<SaveData>();
        SaveSlots saveSlots = GetSaveSlots();
        saveSlots.slotData[i].title = "";
        saveSlots.slotData[i].world = "";
        saveSlots.slotData[i].car = "";
        saveSlots.slotData[i].mapData = null;
        saveData.SaveToJson();
        ShowPanel();
    }

}
