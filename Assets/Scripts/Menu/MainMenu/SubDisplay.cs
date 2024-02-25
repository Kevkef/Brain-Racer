using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubDisplay : MonoBehaviour
{
    DisplayHandler displayHandler;
    public Sprite[] sprites;
    public string specification;
    public GameObject display;
    public void Start(){
      displayHandler = GameObject.Find("Change").GetComponent<DisplayHandler>();
      displayHandler.setDisplay(sprites,specification,display);
    }
}
