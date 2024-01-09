using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    private int CoinAmount;
    // Start is called before the first frame update
    void Start()
    {
        CoinAmounttxt.text = "0";
        CoinAmount = 0;
    }

    public void addCoin()
    {
        CoinAmount++;
        CoinAmounttxt.text = CoinAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
