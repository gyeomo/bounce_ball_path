using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuitScript : MonoBehaviour {
    public Button quit;
    public GameObject QuitPanel;
    public Button noBtn;
    public Button yesBtn;
    // Use this for initialization
    void Start () {
        quit.onClick.AddListener(Quit);
        noBtn.onClick.AddListener(NoBtn);
        yesBtn.onClick.AddListener(YesBtn);
    }
	
	void Quit()
    {
        QuitPanel.SetActive(true);
    }
    void NoBtn()
    {
        QuitPanel.SetActive(false);
    }
    void YesBtn()
    {
        Application.Quit();
    }
    void FixedUpdate()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                QuitPanel.SetActive(true);
            }
        }
    }
}
