using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private int currCoins;
    private int concentrationpoints;

    // Start is called before the first frame update
    void Start()
    {
        currCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addCurrCoin()
    {
        currCoins++;
        UIOverlay.instance.addCoin();
    }

    public int getCurrCoins()
    {
        return currCoins;
    }
    public int getCoins()
    {
        return PlayerPrefs.GetInt("Coins");
    }

    private void ApplyCoins()
    {
        int coins = PlayerPrefs.GetInt("Coins") + currCoins;
        PlayerPrefs.SetInt("Coins", coins);
    }

    private void ApplyPoints()
    {
        int points = PlayerPrefs.GetInt("Points") + concentrationpoints;
        PlayerPrefs.SetInt("Points", points);
    }

    public void setConcentrationPoints(int points)
    {
        concentrationpoints = points;
    }

    public void save()
    {
        ApplyCoins();
        ApplyPoints();
        EEGData.instance.Disconnect();
    }
}
