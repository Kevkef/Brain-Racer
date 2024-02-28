using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.Loading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using System.Threading;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    AudioManager audioManager;
    SaveManager saveManager;
    EEGData eegData;
    public GameObject cars;
    public GameObject loadingScreen;
    public GameObject carSkins;
    public GameObject saveSlotMessage;
    public GameObject eegWarning;
    public Button optionButton;
    public GameObject mainMenu;
    ParentOptionHandler parentOptionHandler;
    private int speedStat = 8;
    private float airStat = 0.115f;
    private float accStat = 0.0985f;
    private int tankStat = 14;
    private int COMStat = 4;

    private bool newGame;
    private SlotData slotData;
    private Boolean isConnected;
    private void Start(){
        parentOptionHandler = GameObject.Find("ParentOption").GetComponent<ParentOptionHandler>();
        parentOptionHandler.AddListenerToBtn(optionButton);
        newGame = false;
        audioManager.StopEngine();
        PlayerPrefs.SetInt("MaxSpeed", speedStat);
        PlayerPrefs.SetFloat("AirResistance", airStat); 
        PlayerPrefs.SetFloat("Acceleration", accStat); 
        PlayerPrefs.SetInt("TankCapacity", tankStat);
        PlayerPrefs.SetInt("ComPort", COMStat);
        setPlayerPrefsInt("SkinCars-1", 1);
        setPlayerPrefsInt("SkinCoins-1", 1);
        setPlayerPrefsInt("Audio-1", 1);
    }
    public void setRetreat(){

        parentOptionHandler.setGameObject(gameObject);
    }
    
    private void setPlayerPrefsInt(string stat, int startValue){
        if(PlayerPrefs.GetInt(stat) == 0){
            PlayerPrefs.SetInt(stat, startValue);
        }
    }
    private void Awake(){
        speedStat = PlayerPrefs.GetInt("MaxSpeed");
        airStat = PlayerPrefs.GetFloat("AirResistance");
        accStat = PlayerPrefs.GetFloat("Acceleration");
        tankStat = PlayerPrefs.GetInt("TankCapacity");
        COMStat = PlayerPrefs.GetInt("ComPort", COMStat);
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        eegData = GameObject.Find("EEGManager").GetComponent<EEGData>();
        if(eegData.Connect()) {
            eegWarning.SetActive(false);
            isConnected = true;
        }
        else {
            eegWarning.SetActive(true);
            isConnected = false;
       }
       if(eegWarning.activeInHierarchy == true){
            carSkins.SetActive(false);
       }
       else {
            carSkins.SetActive(true);
       }
    }

    public void PlayNewGame()
    {
        //Create a Saveslot for the new Game if  there are less then 10 saves
            if(PlayerPrefs.GetInt("NotAvalibleSlots") < 10 && isConnected == true){
                loadingScreen.SetActive(true);
                carSkins.SetActive(false);
                slotData = new SlotData
                {
                    title = DateTime.Now.ToString()
                };
                parentOptionHandler.RemoveListenerFromBtn(optionButton);
                eegData = GameObject.Find("EEGManager").GetComponent<EEGData>();
                new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;
                        slotData.mapData = eegData.readAttentionValues(20).ToList(); //Get Data from EEG and save it as map info
                        slotData.world = null;
                        newGame = true;
                }).Start();
                cars.SetActive(false);   
            }
            else if (PlayerPrefs.GetInt("NotAvalibleSlots") == 10){
                carSkins.SetActive(false);
                loadingScreen.SetActive(false);
                saveSlotMessage.SetActive(true);
            }
            else if(isConnected == false){
                carSkins.SetActive(false);
                loadingScreen.SetActive(false);
                eegWarning.SetActive(true);
            }
   }

    public void QuitGame()
    {
        eegData = GameObject.Find("EEGManager").GetComponent<EEGData>();
        
        try{
            eegData.Disconnect();
            isConnected = false;
        }
        catch{
            isConnected = true;
            Debug.Log("Not Disconnected");
       }
        Application.Quit();
    }

    private void Update()
    {
        if (newGame)
        {
            newGame = false;
            try
            {
                saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
                Debug.Log("Success");
            }
            catch
            {
                Debug.Log("Not working");
            }
            SaveData saveData = GameObject.Find("SaveManager").GetComponent<SaveData>();
            saveManager.setSlotDataScene(slotData);
            saveData.addToSaveSlots(slotData);    //Save the new Save Slot to JSON
            PlayerPrefs.SetInt("NotAvalibleSlots", PlayerPrefs.GetInt("NotAvalibleSlots") + 1);
            try
            {
                eegData.Disconnect();
            }
            catch
            {
                Debug.Log("Not Disconnected");
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
