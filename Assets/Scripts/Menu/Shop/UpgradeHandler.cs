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
    int save0 = 0;
    int save1 = 0;
    int save2= 0;
    int save3= 0;
    private void Start(){
        PlayerPrefs.SetInt("MaxSpeed", save0);
        PlayerPrefs.SetInt("AirResistance", save1); 
        PlayerPrefs.SetInt("Acceleration", save2); 
        PlayerPrefs.SetInt("TankCapacity", save3);
        showMaxSpeed();
        showAirResistance();
        showAcceleration();
        showTankCapacity();
    }

    private void Awake(){
        save0 = PlayerPrefs.GetInt("MaxSpeed");
        save1 = PlayerPrefs.GetInt("AirResistance");
        save2 = PlayerPrefs.GetInt("Acceleration");
        save3 = PlayerPrefs.GetInt("TankCapacity");
    }
    public void upgrade(String specification){
        if(PlayerPrefs.GetInt("Coins") >= PlayerPrefs.GetInt(specification)*10+10){
            Debug.Log(PlayerPrefs.GetInt(specification)*10+10);
        PlayerPrefs.SetInt(specification,PlayerPrefs.GetInt(specification)+1);
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") -PlayerPrefs.GetInt("Cost"+specification));
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
        shopHandler = GameObject.Find("Shop").GetComponent<ShopHandler>();
        shopHandler.UpdateCoins();
        }
        else{
            Debug.Log("No money"+ PlayerPrefs.GetInt("Coins"));
        }
    }
    private void showMaxSpeed(){
        Debug.Log(PlayerPrefs.GetInt("MaxSpeed"));
        PlayerPrefs.SetInt("CostMaxSpeed",costMaxSpeed[PlayerPrefs.GetInt("MaxSpeed")]);
        levelMaxSpeed.text = PlayerPrefs.GetInt("MaxSpeed").ToString() + "/10";
        coinMaxSpeed.text = PlayerPrefs.GetInt("CostMaxSpeed").ToString();
        if(PlayerPrefs.GetInt("MaxSpeed") == 10){
            btnMaxSpeed.enabled = false;
        }
    }
    private void showAirResistance(){
        PlayerPrefs.SetInt("CostAirResistance",costAirResistance[PlayerPrefs.GetInt("AirResistance")]);
        levelAirResistance.text = PlayerPrefs.GetInt("AirResistance").ToString() + "/10";
        Debug.Log(PlayerPrefs.GetInt("AirResistance"));
        coinAirResistance.text = PlayerPrefs.GetInt("CostAirResistance").ToString();
        if(PlayerPrefs.GetInt("AirResistance") == 10){
            btnAirResistance.enabled = false;
        }
    }
    private void showAcceleration(){
        PlayerPrefs.SetInt("CostAcceleration",costAcceleration[PlayerPrefs.GetInt("Acceleration")]);
        levelAcceleration.text = PlayerPrefs.GetInt("Acceleration").ToString() + "/10";
        Debug.Log(PlayerPrefs.GetInt("Acceleration"));
        coinAcceleration.text = PlayerPrefs.GetInt("CostAcceleration").ToString();
        if(PlayerPrefs.GetInt("Acceleration") == 10){
            btnAcceleration.enabled = false;
        }
    }
    private void showTankCapacity(){
        PlayerPrefs.SetInt("CostTankCapacity",costTankCapacity[PlayerPrefs.GetInt("TankCapacity")]);
        levelTankCapacity.text = PlayerPrefs.GetInt("TankCapacity").ToString() + "/10";
        Debug.Log(PlayerPrefs.GetInt("TankCapacity"));
        coinTankCapacity.text = PlayerPrefs.GetInt("CostTankCapacity").ToString();
        if(PlayerPrefs.GetInt("TankCapacity") == 10){
            btnTankCapacity.enabled = false;
        }
    }
}