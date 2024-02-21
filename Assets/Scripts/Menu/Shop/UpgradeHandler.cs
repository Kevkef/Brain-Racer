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
    private int[] costMaxSpeed= {10, 20,30,40,50,60,70,80,90,100, 0};
    private int[] costAirResistance= {10, 20,30,40,50,60,70,80,90,100, 0};
    private int[] costAcceleration= {10, 20,30,40,50,60,70,80,90,100, 0};
    private int[] costTankCapacity= {10, 20,30,40,50,60,70,80,90,100, 0};
    private float[] statMaxSpeed= {8, 15, 22, 29, 36, 43, 50, 57, 64, 71, 78};
    private float[] statAirResistance= {0.115f, 0.116f, 0.117f, 0.118f, 0.119f, 0.12f, 0.1201f,0.1202f, 0.1203f, 0.1204f, 0.1205f};
    private float[] statAcceleration= {0.0985f, 0.099f, 0.0995f, 0.1f , 0.105f, 0.11f, 0.115f, 0.12f, 0.125f, 0.13f, 0.135f};
    private float[] statTankCapacity= {14, 16, 18, 20, 22, 24, 26, 28, 30,32, 34};
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
        }
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
        
    }

    private void show(string spezification, int[] cost, TMP_Text level, TMP_Text coin, Button btn, float[] stat){
        PlayerPrefs.SetInt("Cost"+spezification,cost[PlayerPrefs.GetInt("Level" + spezification)]);
        Debug.Log( PlayerPrefs.GetInt("Level" + spezification).ToString());
        level.text = PlayerPrefs.GetInt("Level" + spezification).ToString() + "/10";
        coin.text = PlayerPrefs.GetInt("Cost"+ spezification).ToString();
        Debug.Log(PlayerPrefs.GetInt("Level" + spezification).ToString());
        if(spezification =="AirResistance"|| spezification == "Acceleration"){
        PlayerPrefs.SetFloat(spezification, stat[PlayerPrefs.GetInt("Level" + spezification)]);
        }
        else {
            PlayerPrefs.SetInt(spezification, (int)stat[PlayerPrefs.GetInt("Level" + spezification)]);
        }
        if(PlayerPrefs.GetInt("Coins") < PlayerPrefs.GetInt("Level" +spezification)*10+10){
             btn.interactable = false;
             coin.text = PlayerPrefs.GetInt("Cost"+ spezification).ToString() +"\n" +"Not enough coins";
        }
        if(PlayerPrefs.GetInt("Level"+spezification) == 10){
            btn.interactable = false;
            coin.text = "Fully upgraded";
        }
    }
}