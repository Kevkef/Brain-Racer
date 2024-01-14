using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGroup : MonoBehaviour
{
    public GameObject car;
    public GameObject terrain;

    private int indexTerrain = 1;
    // Start is called before the first frame update
    void Start()
    {
        indexTerrain = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(car.transform.position.x > 500 * indexTerrain - 50)
        {
            indexTerrain++;
            nextTerrain();
        }
    }

    void nextTerrain()
    {
        GameObject newterrain = Instantiate(terrain);
        newterrain.transform.parent = this.gameObject.transform;
    }

    public int getIndex()
    {
        return indexTerrain;
    }
}
