using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {
    private RaycastHit2D hit;
    private RaycastHit2D ray;
    private LineRenderer line;
    private Vector3 endPos;    
    private Vector3 currentPos;
    private Vector3 firstPos;
    private Vector3 reflect;
    private Vector3 rayVector;
    private bool startFlag;
    private bool endFlag;
    private int increase;
    private BallMove ballMove;
    public Material material;
    public GameObject Portal;
    public GameObject Tunnel;
    public GameObject ExitT;
    private int playerPref;
    private Vector3 ballPos;
    private int remainingNum;
    void Awake () {
        ballMove = GameObject.Find("Ball").GetComponent<BallMove>();
        endFlag = true;
    }
	public bool GetFlag()
    {
        return endFlag;
    }
    const string Ball = "Ball";
    const string PortalE = "PortalE";
    const string TunnelE = "TunnelE";
    const string Destination = "Destination";
    void Update() {
        if (endFlag)
        {
            if (Input.GetMouseButtonDown(0))// && Input.touchCount == 1)
            {
                startFlag = false;
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                ballPos = ballMove.getBallPos();
                playerPref = PlayerPrefs.GetInt("Hint");
                remainingNum = ballMove.RemainingNum;
                if (hit)
                {
                    if (hit.transform.tag.Equals(Ball))
                    {
                        startFlag = true;
                        createLine();
                    }
                }
            }
	        if(Input.GetMouseButton(0) && startFlag){
                increase = 0;
                currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentPos.z = 0;
                firstPos = ballPos + (currentPos - ballPos).normalized * 0.87f;
                ray = Physics2D.CircleCast(firstPos, 0.435f, (currentPos - ballPos).normalized, Mathf.Infinity);
                rayVector = ray.point+ ray.normal * 0.435f;
                rayVector.z = 0;
               // Debug.DrawRay(firstPos, (rayVector-firstPos), Color.green);
                 line.SetPosition(0, firstPos- (currentPos - ballPos).normalized * 0.87f);
                 line.SetPosition(1, rayVector);
                if (playerPref.Equals(1))
                {
                    line.positionCount = remainingNum + 2;
                    for (int i = 2; i < remainingNum + 2 + increase; i++)
                    {
                        reflect = Vector3.Reflect((rayVector - firstPos).normalized, ray.normal);
                        if (Portal != null)
                        {
                            if (ray)
                            {
                                if (ray.transform.tag.Equals(PortalE))
                                {
                                    increase++;
                                    line.positionCount += 2;
                                    reflect = (rayVector - firstPos);
                                    rayVector = new Vector3(Portal.transform.position.x + 0.5f, Portal.transform.position.y, 0);
                                    line.SetPosition(i, rayVector);
                                }
                            }
                        }
                        if (Tunnel != null)
                        {
                            if (ray)
                            {
                                if (ray.transform.tag.Equals(TunnelE))
                                {
                                    increase++;
                                    line.positionCount += 2;
                                    reflect = (ExitT.transform.position - Tunnel.transform.position);
                                    rayVector = new Vector3(ExitT.transform.position.x, ExitT.transform.position.y, 0);
                                    line.SetPosition(i, rayVector);
                                }
                            }
                        }
                        ray = Physics2D.CircleCast(rayVector, 0.435f, reflect.normalized, Mathf.Infinity, 1 << 0);
                        firstPos = rayVector;
                        rayVector = ray.point + ray.normal * 0.435f;
                        rayVector.z = 0;
                        // Debug.DrawRay(firstPos, (rayVector - firstPos), Color.green);
                        line.SetPosition(i+ increase, rayVector);
                        if (ray)
                        {
                            if (ray.transform.tag.Equals(Destination))
                            {
                                line.positionCount = i+ increase + 1;
                                break;
                            }
                        }
                    }
                }
            }
            if (Input.GetMouseButtonUp(0) && startFlag)// && Input.touchCount == 1)
            {
                endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                ballMove.MoveValueSet(endPos);
                ballMove.MoveFlagSet(true);
                endFlag = false;
                line.gameObject.SetActive(false);
                line = null;
            }
        }
    }
    private void createLine()
    {
        line = new GameObject("Line").AddComponent<LineRenderer>();
        line.material = material;
        line.positionCount =2;
        line.startWidth = 0.05f;
        line.endWidth = 0.05f;
        //line.startColor = Color.red;
        //line.endColor = Color.red;
        line.useWorldSpace = true;
      //  line.tag = "Line";
    }


}
