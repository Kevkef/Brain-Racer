using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayHandler : MonoBehaviour
{
    public void setDisplay( Sprite[] sprites, string spezification, GameObject display){
        int i = PlayerPrefs.GetInt("Selected"+ spezification);
        if(spezification != "SkinCars"){
        display.GetComponent<Image>().sprite = sprites[i];
        }
        else {
            display.GetComponent<SpriteRenderer>().sprite = sprites[i];
        }
    }
}
