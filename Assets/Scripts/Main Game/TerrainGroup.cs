using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGroup : MonoBehaviour
{
    public GameObject car;
    public GameObject terrain;

    private bool waiting;
    private int indexTerrain = 1;
    // Start is called before the first frame update
    void Start()
    {
        waiting = true;
        indexTerrain = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(car.transform.position.x > 500 * (indexTerrain - 1) - 100 || waiting)
        {
            Debug.Log("next Terrain");
            nextTerrain();
        }
    }

    void nextTerrain()
    {
        GameObject newterrain = Instantiate(terrain);
        newterrain.transform.parent = this.gameObject.transform;
        if (newterrain.GetComponent<TerrainScript>().generateMap(indexTerrain))
        {
            indexTerrain++;
            waiting = false;
        }
        else
        {
            Destroy(newterrain);
            waiting = true;
        }
    }

    public int getIndex()
    {
        return indexTerrain;
    }
}
