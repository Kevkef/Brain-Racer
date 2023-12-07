using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerPref : MonoBehaviour
{
    public Slider music;
    public Slider sfx;
    public void SaveMusic(){
        PlayerPrefs.SetFloat("MusicVol", music.value);
    }
    public void SaveSFX(){
        PlayerPrefs.SetFloat("SFXVol", sfx.value);
    }

    public void Start(){
        music.value = PlayerPrefs.GetFloat("MusicVol");
        sfx.value = PlayerPrefs.GetFloat("SFXVol");
    }
    public void DeleteData()
    {
        //    PlayerPref.DeleteData(key);
        PlayerPrefs.DeleteAll();
    }
}
