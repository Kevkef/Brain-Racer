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
    public void Start(){
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        base.shopItemSkinSO = audioItemSOs;
        base.Start();
    }
    public void click(int btnNr){
        image = square[btnNr].GetComponent<Image>();
        if(image.sprite == play){
            image.sprite = pause;
            StartCoroutine(playForSeconds(btnNr));
        }
        else{
            audioManager.StopSFX();
            image.sprite = play;
            Debug.Log("In wrong colume");
        }
        
    }
    IEnumerator playForSeconds(int btnNr)
    {
        audioManager.PlaySFX(audioItemSOs[btnNr].audioClip);
        audioManager.pauseMusic();
        yield return new WaitForSeconds(10);
        audioManager.StopSFX();
        audioManager.startMusic();
    }
}