using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void startScene(string name)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(name);
        //EEGData.instance.Disconnect();
    }
}
