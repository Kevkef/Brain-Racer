using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudio : MonoBehaviour
{
    AudioManager audioManager;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        audioManager.PlayEngine();
        audioSource = GameObject.FindGameObjectWithTag("Engine").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = PlayerPrefs.GetFloat("EngineMultiplier")* EEGData.instance.nextAttentionValue() / 100f;
        audioSource.pitch = EEGData.instance.nextAttentionValue() /33.33f;
    }
}
