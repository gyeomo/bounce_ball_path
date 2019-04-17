using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelector : MonoBehaviour {
    public Button Level1;
    public Button Level2;
    public Button Level3;
    public Button back;
    public Button quit;
    public Text SelectorText1;
    public Text SelectorText2;
    public Text SelectorText3;
    public Text SelectorText4;
    public Text SelectorText5;
    public Text SelectorText6;  
    public Button Selector1;
    public Button Selector2;
    public Button Selector3;
    public Button Selector4;
    public Button Selector5;
    public Button Selector6;
    public Button Left;
    public Button Right;
    public GameObject LevelSelector;
    public GameObject StageSeletor;
    public Sprite lockImage;
    public Sprite whiteImage;
    private int SelectNum;
    // Use this for initialization
    const string GameStage = "GameStage";
    const string Stage = "Stage ";
    const string Hint = "Hint";
    void Start()
    {
        Level1.onClick.AddListener(Level1Func);
        Level2.onClick.AddListener(Level2Func);
        Level3.onClick.AddListener(Level3Func);
        back.onClick.AddListener(backFunc);
        Selector1.onClick.AddListener(Selector1Func);
        Selector2.onClick.AddListener(Selector2Func);
        Selector3.onClick.AddListener(Selector3Func);
        Selector4.onClick.AddListener(Selector4Func);
        Selector5.onClick.AddListener(Selector5Func);
        Selector6.onClick.AddListener(Selector6Func);
        Left.onClick.AddListener(LeftFunc);
        Right.onClick.AddListener(RightFunc);
    }
    void ButtonImageChange()
    {
        if (PlayerPrefs.GetInt(GameStage + (SelectNum)).Equals(1))
            Selector1.gameObject.GetComponent<Image>().sprite = whiteImage;
        else
            Selector1.gameObject.GetComponent<Image>().sprite = lockImage;
        if (PlayerPrefs.GetInt(GameStage + (SelectNum + 1)).Equals(1))
            Selector2.gameObject.GetComponent<Image>().sprite = whiteImage;
        else
            Selector2.gameObject.GetComponent<Image>().sprite = lockImage;
        if (PlayerPrefs.GetInt(GameStage + (SelectNum + 2)).Equals(1))
            Selector3.gameObject.GetComponent<Image>().sprite = whiteImage;
        else
            Selector3.gameObject.GetComponent<Image>().sprite = lockImage;
        if (PlayerPrefs.GetInt(GameStage + (SelectNum + 3)).Equals(1))
            Selector4.gameObject.GetComponent<Image>().sprite = whiteImage;
        else
            Selector4.gameObject.GetComponent<Image>().sprite = lockImage;
        if (PlayerPrefs.GetInt(GameStage + (SelectNum + 4)).Equals(1))
            Selector5.gameObject.GetComponent<Image>().sprite = whiteImage;
        else
            Selector5.gameObject.GetComponent<Image>().sprite = lockImage;
        if (PlayerPrefs.GetInt(GameStage + (SelectNum + 5)).Equals(1))
            Selector6.gameObject.GetComponent<Image>().sprite = whiteImage;
        else
            Selector6.gameObject.GetComponent<Image>().sprite = lockImage;
    }
    void Level1Func()
    {
        back.gameObject.SetActive(true);
        quit.gameObject.SetActive(false);
        LevelSelector.SetActive(false);
        StageSeletor.SetActive(true);
        SelectNum = 1;
        ButtonImageChange();
        SelectorText1.text = Stage + SelectNum;
        SelectorText2.text = Stage + (SelectNum + 1);
        SelectorText3.text = Stage + (SelectNum + 2);
        SelectorText4.text = Stage + (SelectNum + 3);
        SelectorText5.text = Stage + (SelectNum + 4);
        SelectorText6.text = Stage + (SelectNum + 5);
    }
    void Level2Func()
    {
        back.gameObject.SetActive(true);
        quit.gameObject.SetActive(false);
        LevelSelector.SetActive(false);
        StageSeletor.SetActive(true);
        SelectNum = 31;
        ButtonImageChange();
        SelectorText1.text = Stage + SelectNum;
        SelectorText2.text = Stage + (SelectNum + 1);
        SelectorText3.text = Stage + (SelectNum + 2);
        SelectorText4.text = Stage + (SelectNum + 3);
        SelectorText5.text = Stage + (SelectNum + 4);
        SelectorText6.text = Stage + (SelectNum + 5);
    }
    void Level3Func()
    {
        back.gameObject.SetActive(true);
        quit.gameObject.SetActive(false);
        LevelSelector.SetActive(false);
        StageSeletor.SetActive(true);
        SelectNum = 61;
        ButtonImageChange();
        SelectorText1.text = Stage + SelectNum;
        SelectorText2.text = Stage + (SelectNum + 1);
        SelectorText3.text = Stage + (SelectNum + 2);
        SelectorText4.text = Stage + (SelectNum + 3);
        SelectorText5.text = Stage + (SelectNum + 4);
        SelectorText6.text = Stage + (SelectNum + 5);
    }
    void backFunc()
    {
        back.gameObject.SetActive(false);
        quit.gameObject.SetActive(true);
        LevelSelector.SetActive(true);
        StageSeletor.SetActive(false);
    }
    void Selector1Func()
    {
        if (PlayerPrefs.GetInt(GameStage + (SelectNum)).Equals(1))
        {
            LevelSelector.SetActive(false);
            StageSeletor.SetActive(false);
            PlayerPrefs.SetInt(Hint, 0);
            PlayerPrefs.Save();
            SceneManager.LoadScene(SelectNum + 1, LoadSceneMode.Single);
            System.GC.Collect();

        }
    }
    void Selector2Func()
    {
        if (PlayerPrefs.GetInt(GameStage + (SelectNum + 1)).Equals(1))
        {
            LevelSelector.SetActive(false);
            StageSeletor.SetActive(false);
            PlayerPrefs.SetInt(Hint, 0);
            PlayerPrefs.Save();
            SceneManager.LoadScene(SelectNum + 2, LoadSceneMode.Single);
            System.GC.Collect();

        }
    }
    void Selector3Func()
    {
        if (PlayerPrefs.GetInt(GameStage + (SelectNum + 2)).Equals(1))
        {
            LevelSelector.SetActive(false);
            StageSeletor.SetActive(false);
            PlayerPrefs.SetInt(Hint, 0);
            PlayerPrefs.Save();
            SceneManager.LoadScene(SelectNum + 3, LoadSceneMode.Single);
            System.GC.Collect();
        }
    }
    void Selector4Func()
    {
        if (PlayerPrefs.GetInt(GameStage + (SelectNum + 3)).Equals(1))
        {
            LevelSelector.SetActive(false);
            StageSeletor.SetActive(false);
            PlayerPrefs.SetInt(Hint, 0);
            PlayerPrefs.Save();
            SceneManager.LoadScene(SelectNum + 4, LoadSceneMode.Single);
            System.GC.Collect();
        }
    }
    void Selector5Func()
    {
        if (PlayerPrefs.GetInt(GameStage + (SelectNum + 4)).Equals(1))
        {
            LevelSelector.SetActive(false);
            StageSeletor.SetActive(false);
            PlayerPrefs.SetInt(Hint, 0);
            PlayerPrefs.Save();
            SceneManager.LoadScene(SelectNum + 5, LoadSceneMode.Single);
            System.GC.Collect();
        }
    }
    void Selector6Func()
    {
        if (PlayerPrefs.GetInt(GameStage + (SelectNum + 5)).Equals(1))
        {
            LevelSelector.SetActive(false);
            StageSeletor.SetActive(false);
            PlayerPrefs.SetInt(Hint, 0);
            PlayerPrefs.Save();
            SceneManager.LoadScene(SelectNum + 6, LoadSceneMode.Single);
            System.GC.Collect();        
        }
    }
    void LeftFunc()
    {
        if (SelectNum != 1 && SelectNum != 31 && SelectNum != 61)
        {
            SelectNum -= 6;
            ButtonImageChange();
            SelectorText1.text = Stage + SelectNum;
            SelectorText2.text = Stage + (SelectNum + 1);
            SelectorText3.text = Stage + (SelectNum + 2);
            SelectorText4.text = Stage + (SelectNum + 3);
            SelectorText5.text = Stage + (SelectNum + 4);
            SelectorText6.text = Stage + (SelectNum + 5);
            
        }
    }
    void RightFunc()
    {
        if (SelectNum != 25 && SelectNum != 55 && SelectNum != 85)
        {
            SelectNum += 6;
            ButtonImageChange();
            SelectorText1.text = Stage + SelectNum;
            SelectorText2.text = Stage + (SelectNum + 1);
            SelectorText3.text = Stage + (SelectNum + 2);
            SelectorText4.text = Stage + (SelectNum + 3);
            SelectorText5.text = Stage + (SelectNum + 4);
            SelectorText6.text = Stage + (SelectNum + 5);
        }
    }
}