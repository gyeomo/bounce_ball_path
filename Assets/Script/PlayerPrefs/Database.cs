using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Database : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (!PlayerPrefs.HasKey("GameStage1"))
        {
            PlayerPrefs.SetInt("GameStage1", 1);
            for (int i = 2;i<= SceneManager.sceneCountInBuildSettings - 2; i++)
            {
                PlayerPrefs.SetInt("GameStage"+i,0);                
            }
            PlayerPrefs.Save();
        }
    }
	
    public int GetData(string key)
    {
        if (!PlayerPrefs.HasKey(key))
            return -1;
        return PlayerPrefs.GetInt("key");
    }
    public void SetData(string key, int data)
    {
        PlayerPrefs.SetInt(key, data);
        PlayerPrefs.Save();
    }
}
