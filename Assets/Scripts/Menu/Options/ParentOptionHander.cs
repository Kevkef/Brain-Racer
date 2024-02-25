using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentOptionHandler : MonoBehaviour
{
    private static ParentOptionHandler instance;
    public GameObject options;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake(){
       if (instance != null && instance != this) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
    public void activateOptions()
    {
        options.SetActive(true);
    }
    public void deactivateOptions()
    {
        options.SetActive(false);
    }
    public Boolean isOptionActive()
    {
        if(options.activeInHierarchy == true){
            return true;
        }
        else {
            return false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
