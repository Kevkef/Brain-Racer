using System;
using UnityEngine;

public class ParentOptionHandler: MonoBehaviour{
    private static OptionHandler instance;
    public GameObject options;
    private void Awake(){
       if (instance != null && instance != this) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
    public void activateOptions(){
        options.SetActive(true);
    }
    public void deactivateOptions(){
        options.SetActive(true);
    }
    public Boolean isActive(){
        if(options.activeInHierarchy == true){
            return true;
        }
        else {
            return false;
        }
    }
}