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
    // Start is called before the first frame update
    void Start()
    {
        showPanel();
    }
    public void showPanel(){
        SaveData saveData = GameObject.Find("Save").GetComponent<SaveData>();
        SaveSlots saveSlots = saveData.LoadFromJson();
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

    public void loadGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }    
}
