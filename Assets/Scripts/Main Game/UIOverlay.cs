using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UIOverlay : MonoBehaviour
{

    #region Singleton

    public static UIOverlay instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Warning, several UIOverlays found!");
            return;
        }
        instance = this;
    }
    #endregion
    public TMP_Text CoinAmounttxt;
    public GameObject endScreen;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject pauseScreen;
    public GameObject eegWarning;
    public Slider fuelSlider;
    public Slider attentionSlider;
    public TMP_Text attentiontxt;
    public GameObject mathmode;
    public TMP_Text endAttentionavg;
    public TMP_Text endAttentionpeak;
    public TMP_Text endAttentionlow;
    public TMP_Text endTime;
    public TMP_Text endPoints;
    public TMP_Text endCoins;
    public AudioClip audioClip;
    AudioManager audioManager;
    private int CoinAmount;
    private bool pause;
    // Start is called before the first frame update
    void Start()
    {
        CoinAmounttxt.text = "0";
        CoinAmount = 0;
        pause = false;
        fuelSlider.maxValue = PlayerPrefs.GetInt("TankCapacity");
        fuelSlider.value = PlayerPrefs.GetInt("TankCapacity");
        if(PlayerPrefs.GetInt("Mathmode") == 1) {
            mathmode.SetActive(true);
        } else
        {
            mathmode.SetActive(false);
        }
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void addCoin()
    {
        CoinAmount++;
        CoinAmounttxt.text = CoinAmount.ToString();
    }

    // Update is called once per frame

    public void showEndScreen(float averageAttention, int peakAttention, int floorAttention, float time, int points, int coins)
    {
        endScreen.SetActive(true);
        audioManager.PlaySFX(audioClip);
        endAttentionavg.text = averageAttention.ToString() + "%";
        endAttentionpeak.text = peakAttention.ToString() + "%";
        endAttentionlow.text = floorAttention.ToString() + "%";
        endTime.text = "Total time: " + time.ToString() + " sec";
        endPoints.text = "Total attention Points: " + points.ToString();
        endCoins.text = "Total Coins: " + coins.ToString();
    }

    public void updatefuel(float fuel)
    {
        fuelSlider.value = fuel;
    }

    public void updateAttention( int attention)
    {
        attentionSlider.value = attention;
        attentiontxt.text = (attention + "%");
    }
    void Update()
    {
        if (Input.GetKeyDown("p") || Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                pauseGame(false);
            } else
            {
                pauseGame(true);
            }

        }
        
    }

    public void pauseGame(bool pause, bool eegDataMissing = false)
    {
        if (!pause)
        {
            this.pause = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            this.pause = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0.0f;
            if (eegDataMissing)
            {
                eegWarning.SetActive(true);
            }
            else
            {
                eegWarning.SetActive(false);
            }
        }
    }
}
