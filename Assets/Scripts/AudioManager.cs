using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---AudioSource---")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

     [Header("---AudioClip---")]
    public AudioClip standard;
    public AudioClip death;
    private void Awake(){
        DontDestroyOnLoad(gameObject);
    }
    private void Start(){
        musicSource.clip=standard;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }
}
