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
    public GameObject boughtEverything;
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
    private void OnEnable(){
        boughtEverything.SetActive(false);
        PlayerPrefs.SetInt("MaxSpeed", save0);
        PlayerPrefs.SetInt("AirResistance", save1); 
        PlayerPrefs.SetInt("Acceleration", save2); 
        PlayerPrefs.SetInt("TankCapacity", save3);
        show("MaxSpeed", costMaxSpeed, levelMaxSpeed ,coinMaxSpeed, btnMaxSpeed);
        show("AirResistance",costAirResistance,levelAirResistance, coinAirResistance, btnAirResistance);
        show("Acceleration", costAcceleration, levelAcceleration, coinAcceleration, btnAcceleration);
        show("TankCapacity", costTankCapacity, levelTankCapacity, coinTankCapacity, btnTankCapacity);
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
                show(specification, costMaxSpeed, levelMaxSpeed ,coinMaxSpeed, btnMaxSpeed);
                break;
            case "AirResistance": 
                show(specification,costAirResistance,levelAirResistance, coinAirResistance, btnAirResistance);
                break;
            case "Acceleration": 
                show(specification, costAcceleration, levelAcceleration, coinAcceleration, btnAcceleration);
                break;
            case "TankCapacity": 
                show(specification, costTankCapacity, levelTankCapacity, coinTankCapacity, btnTankCapacity);
                break;
        }
        shopHandler = GameObject.Find("Shop").GetComponent<ShopHandler>();
        shopHandler.UpdateCoins();
        }
        else{
            Debug.Log("No money"+ PlayerPrefs.GetInt("Coins"));
        }
    }

    private void show(string spezification, int[] cost, TMP_Text level, TMP_Text coin, Button btn){
        PlayerPrefs.SetInt("Cost"+spezification,cost[PlayerPrefs.GetInt(spezification)]);
        level.text = PlayerPrefs.GetInt(spezification).ToString() + "/10";
        coin.text = PlayerPrefs.GetInt("Cost"+ spezification).ToString();
        if(PlayerPrefs.GetInt(spezification) == 10){
            btn.enabled = false;
        }
    }
}