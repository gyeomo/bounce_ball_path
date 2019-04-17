using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Arrive : MonoBehaviour {
    private BallMove ballMove;
    // Use this for initialization
    const string GameStage = "GameStage";
    const string Ball = "Ball";
    const string Hint = "Hint";
    void Start () {
        ballMove = GameObject.Find("Ball").GetComponent<BallMove>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Ball))
        {
            if (!SceneManager.GetActiveScene().buildIndex.Equals(SceneManager.sceneCountInBuildSettings - 1))
            {
                PlayerPrefs.SetInt(GameStage + (SceneManager.GetActiveScene().buildIndex), 1);
                PlayerPrefs.SetInt(Hint, 0);
                PlayerPrefs.Save();
            }
            ballMove.StopBall(true);
        }
    }
}
