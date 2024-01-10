using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class MainMenu : MonoBehaviour
{
    AudioManager audioManager;
    SaveManager saveManager;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void PlayNewGame()
    {
        //Create a Saveslot for the new Game if  there are less then 10 saves
        if(PlayerPrefs.GetInt("AvalibleSlots") > 0){
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
                for(int x = 0; x < 5; x++){
                    slotData.mapData.Add(5);
                }
                for(int x = 5; x < 100; x++){
                slotData.mapData.Add(Random.Range(1,10));
                }
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else{
            Debug.Log("Bitte einen Saveslot vorher löschen und diese Nachrricht dem Nutzer anzeigen");
        }
   }
    public void QuitGame()
    {
        Application.Quit();
    }
}
