using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPoints : MonoBehaviour
{
    private Stats stats;
    public AudioClip audioClip;
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        stats = GameObject.Find("GameManager").GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            audioManager.PlaySFX(audioClip);
            Destroy(collision.gameObject.transform.parent.gameObject);
            stats.addCurrCoin();
        }
    }
}
