using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public SaveSlots saveSlots ; //Used as a "puppet" to save to JSON
    public void Start(){
    }
    public void addToSaveSlots(SlotData slotData){
        //Called from Main Menu and used to save the new Game
        int i = 0;
        while(saveSlots.slotData[i].title != ""){
            i++;
        }
        saveSlots.slotData[i] = slotData;
        SaveToJson();
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
    public void SaveToJson(){
        //Save the Slotes to JSON
        string slotData = JsonUtility.ToJson(saveSlots);
        string filePath = Application.persistentDataPath + "/SlotData.json";
        System.IO.File.WriteAllText(filePath, slotData);
    }

    public SaveSlots LoadFromJson(){
        //get the saved Data
        string filePath = Application.persistentDataPath + "/SlotData.json";
        Debug.Log(filePath);
    	string slotData = System.IO.File.ReadAllText(filePath);
        return saveSlots = JsonUtility.FromJson<SaveSlots>(slotData);
    }
}

[System.Serializable]
public class SaveSlots{
    //Spezifie Save Slots, ten save slots
    public SlotData[] slotData = new SlotData[10];
}
