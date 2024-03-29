using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSpawner : MonoBehaviour
{
    public GameObject FuelPrefab;
    public int distance = 100;

    private TerrainScript terrainScript;
    private int xleftBorder;
    // Start is called before the first frame update
    void Start()
    {
        terrainScript = this.gameObject.GetComponent<TerrainScript>();

        xleftBorder = terrainScript.leftBorderX + 5;
        SpawnFuel();
    }

    private void SpawnFuel()
    {
        int x = xleftBorder + distance;
        while(x <= xleftBorder + terrainScript.MapLength)
        {
            GameObject fuel = Instantiate(FuelPrefab, new Vector2(x, 70), Quaternion.identity);
            fuel.transform.parent = this.gameObject.transform;
            x += distance;
        }
    }
}
