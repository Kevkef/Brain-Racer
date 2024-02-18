using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionHandler : MonoBehaviour
{
    public GameObject MainMenu;
    public  GameObject Shop;
    public GameObject Save;
    
    public Toggle toggleMeditation;
    public Toggle toggleAttention;

    private int level;

    void Start(){
        if(PlayerPrefs.GetInt("Datatype") == 1){
            toggleMeditation.isOn = true;
            toggleAttention.isOn = false;
        }
    }
    public void SetLevel(int canvasNr){
        level = canvasNr;
    }
    public void closeOptions(){
        //open the canvas where Options was called from
        if(level == 0){
            MainMenu.SetActive(true);
        }
        else if(level == 1){
            Save.SetActive(true);
        }
        else if(level == 2){
            Shop.SetActive(true);
        }
        else {
            Debug.Log("Error while closing options");
        }
    }
     public void changeDatatype(){
       if(PlayerPrefs.GetInt("Datatype") == 0){
            toggleMeditation.isOn = true;
            toggleAttention.isOn = false;
            PlayerPrefs.SetInt("Datatype",1);
            Debug.Log("Test1");
       }
       else{
            toggleMeditation.isOn = false;
            toggleAttention.isOn = true;
            PlayerPrefs.SetInt("Datatype",0);
            Debug.Log("Test2");
       }

    }
}
