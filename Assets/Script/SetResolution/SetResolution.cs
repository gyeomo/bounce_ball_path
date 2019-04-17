using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SetResolution : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(Screen.width * 3 / 2, Screen.width, true);
        Application.targetFrameRate = 60;
        SceneManager.LoadScene("HomePage", LoadSceneMode.Single);
    }
}
