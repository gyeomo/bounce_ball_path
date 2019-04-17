using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonScript : MonoBehaviour {
    public Button refresh;
    public Button home;
    public Button nextButton;
    public Button speedBtn;
    public Text SpeedTex;
    public GameObject FinishPanel;
    public Button hint;
    public Button hintY;
    public Button hintN;
    public GameObject HintPanel;
    private BallMove ballMove;
    private GameObject[] movingBlockOJ;
    private MovingBlock[] movingBlocks;
    // Use this for initialization
    void Start () {
        refresh.onClick.AddListener(Refresh);
        home.onClick.AddListener(Home);
        nextButton.onClick.AddListener(NextButton);
        speedBtn.onClick.AddListener(SpeedBtn);
        hint.onClick.AddListener(Hint);
        hintY.onClick.AddListener(HintY);
        hintN.onClick.AddListener(HintN);
        ballMove = GameObject.Find("Ball").GetComponent<BallMove>();
        movingBlockOJ = GameObject.FindGameObjectsWithTag("MovingBlock");
        movingBlocks = new MovingBlock[movingBlockOJ.Length];
        for(int i=0;i< movingBlockOJ.Length; i++)
        {
            movingBlocks[i] = movingBlockOJ[i].GetComponent<MovingBlock>();
        }
        //movingBlock = GameObject.Find("TargetBlock").GetComponent<MovingBlock>();
    }
    void Hint()
    {
        HintPanel.SetActive(true);
    }
    void HintY()
    {
        HintPanel.SetActive(false);
        PlayerPrefs.SetInt("Hint", 1);
        PlayerPrefs.Save();
    }
    void HintN()
    {
        HintPanel.SetActive(false);
    }
    void Refresh()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
     //   System.GC.Collect();
    }
    void Home()
    {
        PlayerPrefs.SetInt("Hint", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        System.GC.Collect();
    }
    void NextButton()
    {
        FinishPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1, LoadSceneMode.Single);
        System.GC.Collect();
    }
    void SpeedBtn()
    {
        if(ballMove.moveSpeed.Equals(0.075f))
        {
            ballMove.moveSpeed *= 2f;
            for (int i = 0; i < movingBlockOJ.Length; i++)
            {
                movingBlocks[i].speed *= 2f;
            }
            SpeedTex.text = "Speed Down";
        }
        else
        {
            ballMove.moveSpeed /= 2.0f;
            for (int i = 0; i < movingBlockOJ.Length; i++)
            {
                movingBlocks[i].speed /= 2.0f;
            }
            SpeedTex.text = "Speed Up";
        }
    }
}
