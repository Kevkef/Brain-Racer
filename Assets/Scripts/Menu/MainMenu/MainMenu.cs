using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using Unity.Loading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class MainMenu : MonoBehaviour
{
    AudioManager audioManager;
    SaveManager saveManager;
    EEGData eegData;
    public SpriteRenderer[] spriteRenderer;
     private float startAcceleration= 0.1f;
    private int startTankCapacity = 5;
    private int startMaxSpeed = 4;
    private float startAirResistance = 0.1f;
    private void Start(){
        setPlayerPrefsFloat("Acceleration", startAcceleration);
        setPlayerPrefsInt("TankCapacity", startTankCapacity);
        setPlayerPrefsInt("MaxSpeed", startMaxSpeed);
        setPlayerPrefsFloat("AirResistance", startAirResistance);
        setPlayerPrefsInt("SkinCars-1", 1);
        setPlayerPrefsInt("SkinCoins-1", 1);
        setPlayerPrefsInt("Audio-1", 1);
        setPlayerPrefsInt("AvalibleSlots", 10);
    }
    private void setPlayerPrefsFloat(string stat, float startValue){
        if(PlayerPrefs.GetFloat(stat) == 0){
            PlayerPrefs.SetFloat(stat, startValue);
        }
    }
    private void setPlayerPrefsInt(string stat, int startValue){
        if(PlayerPrefs.GetInt(stat) == 0){
            PlayerPrefs.SetInt(stat, startValue);
        }
    }
    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        eegData = GameObject.Find("EEGManager").GetComponent<EEGData>();
        try{
            eegData.Connect();
        }
        catch{
            Debug.Log("Not Connected");
       }
    }

    public void PlayNewGame()
    {
        //Create a Saveslot for the new Game if  there are less then 10 saves
            if(PlayerPrefs.GetInt("AvalibleSlots") > 0){
            for(int i = 0; i<4; i++){
                spriteRenderer[i].sortingOrder = 0;
            }
            SlotData slotData = new SlotData
            {
                title = DateTime.Now.ToString()
            };
              //  slotData.mapData = eegData.readAttentionValues(20).ToList(); //Get Data from EEG and save it as map info
                slotData.world = null;
                try{
                    saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
                    Debug.Log("Success");
                }
                catch{
                    Debug.Log("Not working");
                }
                SaveData saveData = GameObject.Find("SaveManager").GetComponent<SaveData>();
                saveManager.setSlotDataScene(slotData);
                saveData.addToSaveSlots(slotData);                                              //Save the new Save Slot to JSON
                PlayerPrefs.SetInt("AvalibleSlots", PlayerPrefs.GetInt("AvalibleSlots")-1);
                eegData = GameObject.Find("EEGManager").GetComponent<EEGData>();
                try{
                    eegData.Disconnect();
                }
                catch{
                    Debug.Log("Not Disconnected");
                }
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else{
            Debug.Log("Bitte einen Saveslot vorher löschen und diese Nachrricht dem Nutzer anzeigen");
        }
   }
    public void QuitGame()
    {
        eegData = GameObject.Find("EEGManager").GetComponent<EEGData>();
        
        try{
            eegData.Disconnect();
        }
        catch{
            Debug.Log("Not Disconnected");
       }
        Application.Quit();
    }
}
