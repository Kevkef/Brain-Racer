using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prewarm : MonoBehaviour
{
    public GameObject car;
    public Sprite[] bodysprites;
    public float prewarmtime = 5f;

    private GameObject skinbody;
    // Start is called before the first frame update
    void Start()
    {
        car.GetComponent<Rigidbody2D>().freezeRotation = true;
        skinbody = GameObject.Find("body");
        skinbody.GetComponent<SpriteRenderer>().sprite = bodysprites[PlayerPrefs.GetInt("SelectedSkinCars")];
    }

    // Update is called once per frame
    void Update()
    {
        if(prewarmtime > 0)
        {
            prewarmtime -= Time.deltaTime;
        } else
        {
            car.GetComponent<Rigidbody2D>().freezeRotation = false;
            this.gameObject.SetActive(false);
        }
    }
}
