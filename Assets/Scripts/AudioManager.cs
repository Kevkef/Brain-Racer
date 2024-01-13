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
    public AudioClip standard;
    public AudioClip engine;
    private void Awake(){
        DontDestroyOnLoad(gameObject);
    }
    private void Start(){
        musicSource.clip=standard;
        musicSource.Play();
    }
    public void pauseMusic(){
        musicSource.Pause();
    }
     public void startMusic(){
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
}
