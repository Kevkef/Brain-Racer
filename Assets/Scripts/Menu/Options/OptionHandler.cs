using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OptionHandler : MonoBehaviour
{
    public GameObject MainMenu;
    public  GameObject Shop;
    public GameObject Save;
    public  TMP_Text BtnText;
    public  TMP_Text ChangeText;
    private int level;

    void Start(){
        if(PlayerPrefs.GetInt("Datatype") == 1){
            BtnText.text = "Attention";
            ChangeText.text = "Meditation";
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
        ChangeText.text = BtnText.text;
       if(BtnText.text == "Attention"){
            BtnText.text = "Meditation";
            PlayerPrefs.SetInt("Datatype",0);
       }
       else{
            BtnText.text = "Attention";
            PlayerPrefs.SetInt("Datatype",1);
       }

    }
}
