using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParentOptionHandler : MonoBehaviour
{
    private static ParentOptionHandler instance;
    public GameObject options;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void AddListenerToBtn(Button btn){
        btn.onClick.AddListener(ActivateOptions);
    }
    public void RemoveListenerFromBtn(Button btn){
          btn.onClick.RemoveListener(ActivateOptions);
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
    public void ActivateOptions()
    {
        options.SetActive(true);
    }
    public void DeactivateOptions()
    {
        options.SetActive(false);
    }
    public Boolean IsOptionActive()
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
