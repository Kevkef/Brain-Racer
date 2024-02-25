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
    public GameObject COMValue;
    public Toggle toggleMeditation;
    public Toggle toggleAttention;
    public GameObject eegWarning;
    private static OptionHandler instance;
    private int level;

    void Start(){
        if(PlayerPrefs.GetInt("Datatype") == 1){
            toggleMeditation.isOn = true;
            toggleAttention.isOn = false;
        }
        COMValue.GetComponent<TMP_Dropdown>().value = (PlayerPrefs.GetInt("ComPort") - 3);
    }
    private void Awake(){
       if (instance != null && instance != this) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
            instance = this;
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
    public void setCOM(){
        PlayerPrefs.SetInt("ComPort",(COMValue.GetComponent<TMP_Dropdown>().value + 3));
        EEGData.instance.Disconnect();
        if (EEGData.instance.Connect())
        {
            eegWarning.SetActive(false);
        }
        else
        {
            Debug.Log("Not Connected");
            eegWarning.SetActive(true);
        }
    }
}
