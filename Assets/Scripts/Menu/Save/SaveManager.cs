using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting.FullSerializer;
using Unity.VisualScripting;
using System;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class SaveManager : MonoBehaviour
{
    public static SlotData slotDataScene;
    // Start is called before the first frame update, slotDataScene is used in multible Scences
    void Start()
    {
    }
    
    public void setSlotDataScene(SlotData saveData){
        //Get GameData from a save or new game and set slotDataScene
        slotDataScene = saveData;
    }
}
