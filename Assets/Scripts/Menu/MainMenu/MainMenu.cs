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
    public GameObject LoadingScreen;
     private float startAcceleration= 0.1f;
    private float startTankCapacity = 5;
    private float startMaxSpeed = 4f;
    private float startAirResistance = 0.1f;
    private void Start(){
        setPlayerPrefsFirst("Acceleration", startAcceleration);
        setPlayerPrefsFirst("TankCapacity", startTankCapacity);
        setPlayerPrefsFirst("MaxSpeed", startMaxSpeed);
        setPlayerPrefsFirst("AirResistance", startAirResistance);
        Debug.Log(PlayerPrefs.GetFloat("MaxSpeed"));
    }
    private void setPlayerPrefsFirst(string stat, float firstTime){
        if(PlayerPrefs.GetFloat(stat) == 0){
            PlayerPrefs.SetFloat(stat, firstTime);
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
        Debug.Log(PlayerPrefs.GetInt("AvalibleSlots"));
        //Create a Saveslot for the new Game if  there are less then 10 saves
        if(PlayerPrefs.GetInt("AvalibleSlots") > 0){
            LoadingScreen.SetActive(true);
            SlotData slotData = new SlotData
            {
                title = DateTime.Now.ToString()
            };
           switch (PlayerPrefs.GetInt("SelectedCars")){
                    case 0:
                        slotData.car = "Basic Car";
                        break;
                    case 1:
                        slotData.car = "Badass Car";
                        break;
                }
                switch(PlayerPrefs.GetInt("SelectedCoins")){
                    case 0:
                        slotData.coin = "Bronze Coin";
                        break;
                    case 1:
                        slotData.coin = "Silver Car";
                        break;
                    case 2:
                        slotData.coin = "Gold Car";
                        break;
                }
                slotData.mapData = eegData.readAttentionValues(20).ToList(); //Get Data from EEG and save it as map info
                slotData.world = null;
                try{
                    saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
                    Debug.Log("Success");
                }
                catch{
                    Debug.Log("Not working");
                }
                saveManager.setSlotDataScene(slotData);
                SaveData saveData = GameObject.Find("SaveManager").GetComponent<SaveData>();
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
