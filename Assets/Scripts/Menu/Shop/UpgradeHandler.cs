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
    private float[] statMaxSpeed= {4,10, 20,30,40,50,60,70,80,90,100};
    private float[] statAirResistance= {0,1f,10, 20,30,40,50,60,70,80,90,100};
    private float[] statAcceleration= {0,1f,10, 20,30,40,50,60,70,80,90,100};
    private float[] statTankCapacity= {5,10, 20,30,40,50,60,70,80,90,100};
    ShopHandler shopHandler;
    int save0 = 0;
    int save1 = 0;
    int save2= 0;
    int save3= 0;
    private void OnEnable(){
        boughtEverything.SetActive(false);
    }
    private void Start(){
        PlayerPrefs.SetInt("LevelMaxSpeed", save0);
        PlayerPrefs.SetInt("LevelAirResistance", save1); 
        PlayerPrefs.SetInt("LevelAcceleration", save2); 
        PlayerPrefs.SetInt("LevelTankCapacity", save3);
        show("MaxSpeed", costMaxSpeed, levelMaxSpeed ,coinMaxSpeed, btnMaxSpeed, statMaxSpeed);
        show("AirResistance",costAirResistance,levelAirResistance, coinAirResistance, btnAirResistance, statAirResistance);
        show("Acceleration", costAcceleration, levelAcceleration, coinAcceleration, btnAcceleration, statAcceleration);
        show("TankCapacity", costTankCapacity, levelTankCapacity, coinTankCapacity, btnTankCapacity, statTankCapacity);
        Debug.Log(PlayerPrefs.GetFloat("MaxSpeed"));
    }

    private void Awake(){
        save0 = PlayerPrefs.GetInt("LevelMaxSpeed");
        save1 = PlayerPrefs.GetInt("LevelAirResistance");
        save2 = PlayerPrefs.GetInt("LevelAcceleration");
        save3 = PlayerPrefs.GetInt("LevelTankCapacity");
    }
    public void upgrade(String specification){
        if(PlayerPrefs.GetInt("Coins") >= PlayerPrefs.GetInt("Level" +specification)*10+10){
            Debug.Log(PlayerPrefs.GetInt("Level" + specification)*10+10);
        PlayerPrefs.SetInt("Level" +specification,PlayerPrefs.GetInt("Level" +specification)+1);
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") -PlayerPrefs.GetInt("Cost"+specification));
        switch(specification){
            case "MaxSpeed": 
                show(specification, costMaxSpeed, levelMaxSpeed ,coinMaxSpeed, btnMaxSpeed, statMaxSpeed);
                break;
            case "AirResistance": 
                show(specification,costAirResistance,levelAirResistance, coinAirResistance, btnAirResistance, statAirResistance);
                break;
            case "Acceleration": 
                show(specification, costAcceleration, levelAcceleration, coinAcceleration, btnAcceleration, statAcceleration);
                break;
            case "TankCapacity": 
                show(specification, costTankCapacity, levelTankCapacity, coinTankCapacity, btnTankCapacity, statTankCapacity);
                break;
        }
        shopHandler = GameObject.Find("Shop").GetComponent<ShopHandler>();
        shopHandler.UpdateCoins();
        Debug.Log(PlayerPrefs.GetFloat("MaxSpeed"));
        }
        else{
            Debug.Log("No money"+ PlayerPrefs.GetInt("Coins"));
        }
    }

    private void show(string spezification, int[] cost, TMP_Text level, TMP_Text coin, Button btn, float[] stat){
        PlayerPrefs.SetInt("Cost"+spezification,cost[PlayerPrefs.GetInt("Level" + spezification)]);
        Debug.Log( PlayerPrefs.GetInt("Level" + spezification).ToString());
        level.text = PlayerPrefs.GetInt("Level" + spezification).ToString() + "/10";
        coin.text = PlayerPrefs.GetInt("Cost"+ spezification).ToString();
        PlayerPrefs.SetFloat(spezification, stat[PlayerPrefs.GetInt("Level" + spezification)]);
        if(PlayerPrefs.GetInt("Level"+spezification) == 10){
            btn.enabled = false;
        }
    }
}