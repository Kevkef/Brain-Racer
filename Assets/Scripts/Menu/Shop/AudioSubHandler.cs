using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioSubHandler : SubHandler
{
    AudioManager audioManager;
    public ShopAudioSO[] audioItemSOs;
    public Sprite play;
    public Sprite pause;
    public GameObject[] square;
    Image image;
    public void OnEnable(){
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        base.shopItemSkinSO = audioItemSOs;
        base.OnEnable();
    }
    public void Click(int btnNr){
        for(int i = 0; i < 4; i++){
            image = image = square[i].GetComponent<Image>();
            audioManager.StopSFX();
        }
        StopCoroutine("playForSeconds");
        image = square[btnNr].GetComponent<Image>();
        if(image.sprite == play){ //
            image.sprite = pause;
            StartCoroutine(playForSeconds(btnNr));
        }
        else{
            audioManager.StopSFX();
            image.sprite = play;
        }
    }
    IEnumerator playForSeconds(int btnNr)
    {
        //Playes a SFX for 10 seconds before music starts playing again
        audioManager.PlaySFX(audioItemSOs[btnNr].audioClip);
        audioManager.PauseMusic();
        yield return new WaitForSeconds(10);
        audioManager.StopSFX();
        audioManager.StartMusic();
        image.sprite = play;
    }
}