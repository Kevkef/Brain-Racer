using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHandler : MonoBehaviour
{
    public void setDisplay( Sprite[] sprites, string gameObjectName, string spezification, GameObject display){
        int i = PlayerPrefs.GetInt("Selected"+ spezification);
        display.GetComponent<SpriteRenderer>().sprite = sprites[i];
    }
}
