using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubDisplay : MonoBehaviour
{
    DisplayHandler displayHandler;
    public Sprite[] sprites;
    public String gameObject;
    public String specification;
    public GameObject display;
    void Start(){
      displayHandler = GameObject.Find("Display").GetComponent<DisplayHandler>();
      displayHandler.setDisplay(sprites,gameObject,specification,display);
    }
}
