using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionHandler : MonoBehaviour
{
    public GameObject MainMenu;
    public  GameObject Shop;
    public GameObject Save;
    private int level;
    public void SetLevel(int canvasNr){
        level = canvasNr;
    }
    public void closeOptions(){
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
}
