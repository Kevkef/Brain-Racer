using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPoints : MonoBehaviour
{
    private Stats stats;
    // Start is called before the first frame update
    void Start()
    {
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
            Destroy(collision.gameObject.transform.parent.gameObject);
            stats.addCurrCoin();
        }
    }
}
