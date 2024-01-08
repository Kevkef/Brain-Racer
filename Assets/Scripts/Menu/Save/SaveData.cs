using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public SaveSlots saveSlots = new SaveSlots();
    public void Start(){
        SaveToJson();
    }
    
    public void SaveToJson(){
        string slotData = JsonUtility.ToJson(saveSlots);
        string filePath = Application.persistentDataPath + "/SlotData.json";
        System.IO.File.WriteAllText(filePath, slotData);
    }

    public SaveSlots LoadFromJson(){
        string filePath = Application.persistentDataPath + "/SlotData.json";
    	string slotData = System.IO.File.ReadAllText(filePath);
        return saveSlots = JsonUtility.FromJson<SaveSlots>(slotData);
    }
}

[System.Serializable]
public class SaveSlots{
    public SlotData[] slotData = new SlotData[10];
}
