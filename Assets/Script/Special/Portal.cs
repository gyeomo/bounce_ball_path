using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    public GameObject exit;
    private Vector2 exitPos;
    private BallMove ballMove;
    void Start()
    {
        ballMove = GameObject.Find("Ball").GetComponent<BallMove>();
        exitPos = new Vector2(exit.transform.position.x+ 0.5f, exit.transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ballMove.TelePort(exitPos);
    }
}
