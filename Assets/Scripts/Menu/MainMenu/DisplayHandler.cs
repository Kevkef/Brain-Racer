using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayHandler : MonoBehaviour
{
    public void setDisplay( Sprite[] sprites, string spezification, GameObject display){
        int i;
        if(spezification != "SkinMath"){
            i = PlayerPrefs.GetInt("Selected"+ spezification);
        }
        else {
            i = PlayerPrefs.GetInt("MathMode");
        }
        if(spezification != "SkinCars" ){
            display.GetComponent<Image>().sprite = sprites[i];
        }
        else {
            display.GetComponent<SpriteRenderer>().sprite = sprites[i];
        }
    }
}
