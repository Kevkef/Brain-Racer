using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---AudioSource---")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource engineSource;

     [Header("---AudioClip---")]
    public AudioClip engine;
    public AudioClip[] audioClips;
    private static AudioManager instance;
    private void Awake(){
       if (instance != null && instance != this) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
    private void Start(){
        musicSource.clip=audioClips[PlayerPrefs.GetInt("SelectedAudio")];
        musicSource.Play();
    }
    public void PauseMusic(){
        musicSource.Pause();
    }
     public void StartSpezificMusic(){
        musicSource.clip= musicSource.clip=audioClips[PlayerPrefs.GetInt("SelectedAudio")];;
        musicSource.Play();
    }
    public void StartMusic(){
         musicSource.Play();
    }
    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }
    public void StopSFX(){
        SFXSource.Stop();
    }
    public void PlayEngine(){
        engineSource.clip=engine;
        engineSource.Play();
    }

    public void StopEngine(){
        engineSource.Stop();
    }
}
