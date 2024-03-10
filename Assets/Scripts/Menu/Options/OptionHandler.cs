using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionHandler : MonoBehaviour
{
    GameObject retreatObject;
    public GameObject COMValue;
    public Toggle toggleMeditation;
    public Toggle toggleAttention;
    public GameObject eegWarning;
    private int level;

    void Start(){
        if(PlayerPrefs.GetInt("Datatype") == 1){
            toggleMeditation.isOn = true;
            toggleAttention.isOn = false;
        }
        COMValue.GetComponent<TMP_Dropdown>().value = (PlayerPrefs.GetInt("ComPort") - 3);
         if (EEGData.instance.Connect())
        {
            eegWarning.SetActive(false);
        }
        else
        {
            eegWarning.SetActive(true);
        }
    }
    public void SetLevel(int canvasNr){
        level = canvasNr;
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
        EEGData.instance.updateDatatype();
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
