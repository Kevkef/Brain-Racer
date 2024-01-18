using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimapcam : MonoBehaviour
{
    public GameObject POI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3(POI.transform.position.x, 25f, -10f);
    }
}
