using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject CoinPrefab;
    public int CoinAmount;
    public Sprite[] coinSkins;

    private Sprite coinSkin;
    private TerrainScript terrainScript;
    private int xleftBorder;
    private int xrightBorder;
    // Start is called before the first frame update
    void Start()
    {
        terrainScript = this.gameObject.GetComponent<TerrainScript>();
        coinSkin = coinSkins[PlayerPrefs.GetInt("SelectedSkinCoins")];
        CoinPrefab.GetComponent<SpriteRenderer>().sprite = coinSkin;

        xleftBorder = terrainScript.leftBorderX + 5;
        xrightBorder = terrainScript.leftBorderX + terrainScript.MapLength - 5;

        SpawnCoins();
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < CoinAmount; i++) {
            float x = Random.Range((float)xleftBorder, (float)xrightBorder);
            GameObject coin = Instantiate(CoinPrefab, new Vector2(x, 70), Quaternion.identity);
            coin.transform.parent = this.gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
