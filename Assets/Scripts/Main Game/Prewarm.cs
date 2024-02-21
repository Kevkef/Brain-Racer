using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Prewarm : MonoBehaviour
{
    public GameObject car;
    public GameObject[] bodymodels;
    public float prewarmtime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        car.GetComponent<Rigidbody2D>().freezeRotation = true;
        GameObject model = GameObject.Find("Model");
        Destroy(model);
        print(PlayerPrefs.GetInt("SelectedSkinCars") + model.name);
        GameObject newModel = (GameObject)UnityEngine.Object.Instantiate(bodymodels[PlayerPrefs.GetInt("SelectedSkinCars")]);
        newModel.transform.parent = car.transform;
        newModel.transform.position = car.transform.position;
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
