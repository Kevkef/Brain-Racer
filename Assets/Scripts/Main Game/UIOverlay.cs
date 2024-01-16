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
    }

    public void addCoin()
    {
        CoinAmount++;
        CoinAmounttxt.text = CoinAmount.ToString();
    }

    // Update is called once per frame

    public void showEndScreen(bool win)
    {
        endScreen.SetActive(true);
        if (win)
        {
            winScreen.SetActive(true);
        } else
        {
            loseScreen.SetActive(true);
        }
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
        if (Input.GetKeyDown("p"))
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
