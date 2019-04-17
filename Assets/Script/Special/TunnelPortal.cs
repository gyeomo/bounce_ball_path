using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelPortal : MonoBehaviour {
    private BallMove ballMove;
    public GameObject tunnel;
    public GameObject exitT;
    // Use this for initialization
    void Start () {
        ballMove = GameObject.Find("Ball").GetComponent<BallMove>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ballMove.TelePort(exitT.transform.position);
        ballMove.MoveValueSet(tunnel.transform.position, exitT.transform.position);
    }
}
