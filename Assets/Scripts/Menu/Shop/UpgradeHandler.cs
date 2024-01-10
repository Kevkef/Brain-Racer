using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

public class UpgradeHandler : MonoBehaviour
{
    public TMP_Text levelMaxSpeed;
    public TMP_Text levelAirResistance;
    public TMP_Text levelAcceleration;
    public TMP_Text levelTankCapacity;
    public Button btnMaxSpeed;
    public Button btnAirResistance;
    public Button btnAcceleration;
    public Button btnTankCapacity;
    private void Start(){
        showMaxSpeed();
        showAcceleration();
        showAirResistance();
        showTankCapacity();
    }
    public void upgrade(String specification){
        PlayerPrefs.SetInt(specification,PlayerPrefs.GetInt(specification)+1);
        switch(specification){
            case "MaxSpeed": 
                showMaxSpeed();
                break;
            case "AirResistance": 
                showAirResistance();
                break;
            case "Acceleration": 
                showAcceleration();
                break;
            case "TankCapacity": 
                showTankCapacity();
                break;
        }
    }
    private void showMaxSpeed(){
        levelMaxSpeed.text = PlayerPrefs.GetInt("MaxSpeed").ToString();
        if(PlayerPrefs.GetInt("MaxSpeed") == 10){
            btnMaxSpeed.enabled = false;
        }
    }
    private void showAirResistance(){
        levelAirResistance.text = PlayerPrefs.GetInt("AirResistance").ToString();
        if(PlayerPrefs.GetInt("AirResistance") == 10){
            btnAirResistance.enabled = false;
        }
    }
    private void showAcceleration(){
        levelAcceleration.text = PlayerPrefs.GetInt("Acceleration").ToString();
        if(PlayerPrefs.GetInt("Acceleration") == 10){
            btnAcceleration.enabled = false;
        }
    }
    private void showTankCapacity(){
        levelTankCapacity.text = PlayerPrefs.GetInt("TankCapacity").ToString();
        if(PlayerPrefs.GetInt("TankCapacity") == 10){
            btnTankCapacity.enabled = false;
        }
    }
}