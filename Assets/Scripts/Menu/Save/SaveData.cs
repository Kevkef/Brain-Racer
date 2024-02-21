using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public SaveSlots saveSlots ; //Used as a "puppet" to save to JSON
    public int saveSlotNumber;
    private static SaveData instance;
    public void Start(){
        try{
            saveSlots = LoadFromJson();
        }
        catch{
            saveSlots = new SaveSlots();
            SaveToJson();
        }
    }
    private void Awake(){
        if (instance != null && instance != this) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
    public void addToSaveSlots(SlotData slotData){
        //Called from Main Menu and used to save the new Game
        saveSlots = LoadFromJson();
        saveSlotNumber = 0;
        while(saveSlots.slotData[saveSlotNumber].title != ""){
            saveSlotNumber++;
            if(saveSlotNumber == 10){
                break;
            }
        }
        if (saveSlotNumber <= 9)
        {
            saveSlots.slotData[saveSlotNumber] = slotData;
            SaveToJson();
        }
    }
    public void deleteFromSaveSlots(int btnNr){
        //Delete a spezified Slot from JSON data
        saveSlots.slotData[btnNr].title = "";
        saveSlots.slotData[btnNr].world = "";
        saveSlots.slotData[btnNr].car = "";
        saveSlots.slotData[btnNr].coin = "";
        saveSlots.slotData[btnNr].mapData = null;
        SaveToJson();
    }
    public void updateSaveSlotdataMap(int newData){
        saveSlots.slotData[saveSlotNumber].mapData.Add(newData);
        SaveToJson();
    }
    public void SaveToJson(){
        //Save the Slotes to JSON
        string slotData = JsonUtility.ToJson(saveSlots);
        string filePath = Application.persistentDataPath + "/SlotData.json";
        System.IO.File.WriteAllText(filePath, slotData);
    }

    public SaveSlots LoadFromJson(){
        //get the saved Data
        string filePath = Application.persistentDataPath + "/SlotData.json";
    	string slotData = System.IO.File.ReadAllText(filePath);
        return saveSlots = JsonUtility.FromJson<SaveSlots>(slotData);
    }
}

[System.Serializable]
public class SaveSlots{
    //Spezifie Save Slots, ten save slots
    public SlotData[] slotData = new SlotData[10];
}
