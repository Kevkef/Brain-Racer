using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayHandler : MonoBehaviour
{
    public void setDisplay( Sprite[] sprites, string spezification, GameObject display){
        int i = PlayerPrefs.GetInt("Selected"+ spezification);
        display.GetComponent<Image>().sprite = sprites[i];
    }
}
