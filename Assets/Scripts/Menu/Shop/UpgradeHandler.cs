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
    public TMP_Text coinMaxSpeed;
    public TMP_Text coinAirResistance;
    public TMP_Text coinAcceleration;
    public TMP_Text coinTankCapacity;
    public Button btnMaxSpeed;
    public Button btnAirResistance;
    public Button btnAcceleration;
    public Button btnTankCapacity;
    private int[] costMaxSpeed= {10, 20,30,40,50,60,70,80,90,100};
    private int[] costAirResistance= {10, 20,30,40,50,60,70,80,90,100};
    private int[] costAcceleration= {10, 20,30,40,50,60,70,80,90,100};
    private int[] costTankCapacity= {10, 20,30,40,50,60,70,80,90,100};
    ShopHandler shopHandler;
    private void Start(){
        PlayerPrefs.DeleteAll();
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
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") -PlayerPrefs.GetInt("Cost"+specification));
        shopHandler = GameObject.Find("Shop").GetComponent<ShopHandler>();
        shopHandler.UpdateCoins();
    }
    private void showMaxSpeed(){
        PlayerPrefs.SetInt("CostMaxSpeed",costMaxSpeed[PlayerPrefs.GetInt("MaxSpeed")]);
        levelMaxSpeed.text = PlayerPrefs.GetInt("MaxSpeed").ToString() + "/10";
        coinMaxSpeed.text = PlayerPrefs.GetInt("CostMaxSpeed").ToString();
        if(PlayerPrefs.GetInt("MaxSpeed") == 10){
            btnMaxSpeed.enabled = false;
        }
    }
    private void showAirResistance(){
        PlayerPrefs.SetInt("CostAirResistance",costAirResistance[PlayerPrefs.GetInt("AirResistance")-1]);
        levelAirResistance.text = PlayerPrefs.GetInt("AirResistance").ToString() + "/10";
        coinAirResistance.text = PlayerPrefs.GetInt("CostAirResistance").ToString();
        if(PlayerPrefs.GetInt("AirResistance") == 10){
            btnAirResistance.enabled = false;
        }
    }
    private void showAcceleration(){
        PlayerPrefs.SetInt("CostAcceleration",costAcceleration[PlayerPrefs.GetInt("Acceleration")-1]);
        levelAcceleration.text = PlayerPrefs.GetInt("Acceleration").ToString() + "/10";
        coinAcceleration.text = PlayerPrefs.GetInt("CostAcceleration").ToString();
        if(PlayerPrefs.GetInt("Acceleration") == 10){
            btnAcceleration.enabled = false;
        }
    }
    private void showTankCapacity(){
        PlayerPrefs.SetInt("CostTankCapacity",costTankCapacity[PlayerPrefs.GetInt("TankCapacity")-1]);
        levelTankCapacity.text = PlayerPrefs.GetInt("TankCapacity").ToString() + "/10";
        coinTankCapacity.text = PlayerPrefs.GetInt("CostTankCapacity").ToString();
        if(PlayerPrefs.GetInt("TankCapacity") == 10){
            btnTankCapacity.enabled = false;
        }
    }
}