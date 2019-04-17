using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelMove : MonoBehaviour {
    private RaycastHit2D hit;
    public GameObject exitT;
    public GameObject tunnel;
    private Vector3 mousePos;
    private BallManager ballManager;
    private float dyM, dxM, dyT, dxT,dyC,dxC, gradientT, gradientM, rotateDegree;
    private bool startFlag, moveFlag = true;
    // Update is called once per frame
    const string ExitT = "ExitT";
    private Transform Etransform;
    private Transform Ttransform;
    void Start()
    {
        ballManager = GameObject.Find("BallManager").GetComponent<BallManager>();
        Etransform = exitT.transform;
        Ttransform = tunnel.transform;
    }
    void Update()
    {
        if (ballManager.GetFlag()) {
            if (Input.GetMouseButtonDown(0))// && Input.touchCount == 1)
            {
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                startFlag = false;
                if (hit)
                {
                    if (hit.transform.tag.Equals(ExitT))
                    {
                        startFlag = true;
                    }
                }

            }
            else if (Input.GetMouseButton(0) && startFlag)
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;
                dxM = mousePos.x - Ttransform.position.x;
                dyM = mousePos.y - Ttransform.position.y;
                gradientM = Mathf.Atan2(dxM, dyM);

                //if (gradientM < 0)
                //   gradientM = -gradientM;
                dxT =Etransform.position.x - Ttransform.position.x;
                dyT = Etransform.position.y - Ttransform.position.y;
                gradientT = Mathf.Atan2(dxT, dyT);

                rotateDegree = ((gradientT - gradientM) * Mathf.Rad2Deg);
                if (moveFlag)
                {
                    if (dxM < 0 && dyM < 0 && dxT > 0 && dyT < 0)
                        Etransform.RotateAround(Ttransform.position, Vector3.forward, -5);
                    else if (dxM > 0 && dyM < 0 && dxT < 0 && dyT < 0)
                        Etransform.RotateAround(Ttransform.position, Vector3.forward, 5);
                    else
                        Etransform.RotateAround(Ttransform.position, Vector3.forward, 10 * rotateDegree * Time.deltaTime);
                }
                else
                {
                    if (Mathf.Atan2(dxC, dyC) > gradientT && gradientT > gradientM)
                        moveFlag = true;
                    else if (Mathf.Atan2(dxC, dyC) < gradientT && gradientT < gradientM)
                        moveFlag = true;
                    if (dxM < 0 && dyM < 0 && dxT > 0 && dyT < 0)
                        moveFlag = false;
                    else if (dxM > 0 && dyM < 0 && dxT < 0 && dyT < 0)
                        moveFlag = false;
                }
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            moveFlag = false;
            dxC = collision.contacts[0].point.x - tunnel.transform.position.x;
            dyC = collision.contacts[0].point.y - tunnel.transform.position.y;
            //Debug.Log("Collision");
        }
    }
}
