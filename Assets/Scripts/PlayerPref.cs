using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerPref : MonoBehaviour
{
    public int coins;
    public Slider music;
    public Slider sfx;
    public Slider engine;

    public void Start(){
        music.value = PlayerPrefs.GetFloat("MusicVol");
        sfx.value = PlayerPrefs.GetFloat("SFXVol");
    }
    public void SaveMusic(){
        PlayerPrefs.SetFloat("MusicVol", music.value);
    }
    public void SaveSFX(){
        PlayerPrefs.SetFloat("SFXVol", sfx.value);
    }
    public void SaveEngine(){
        PlayerPrefs.SetFloat("EngineMultiplier", engine.value);
    }
    public void SaveCoins(){
        PlayerPrefs.SetInt("Coins", coins);
    }
    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
}
