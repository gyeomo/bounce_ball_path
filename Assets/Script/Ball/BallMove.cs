using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BallMove : MonoBehaviour {

    private GameObject Ball;
    private Transform ballTf;
    private Vector2 ballPos;
    private Vector2 moveValue;
    //private float moveSpeed = 0.075f;
    public float moveSpeed;
    private bool moveFlag = false;
    private Vector2 firstPos;
    private bool frameCollisionCheck = false;

    public int RemainingNum;
    public Text countNum;
    public Text FinishText;
    public GameObject FinishPanel;
    public Button NextButton;
    void Awake()
    {
        countNum.text = RemainingNum.ToString();
        Ball = gameObject;
        ballTf = Ball.transform;
        ballPos = Ball.transform.position;
    }
    void FixedUpdate()
    {
        if (moveFlag)
        {
            ballPos.x += moveValue.x * moveSpeed;
            ballPos.y += moveValue.y * moveSpeed;

            ballTf.position = ballPos;
            if (frameCollisionCheck)
            {
                frameCollisionCheck = false;
            }
        }
    }
    Vector3 vector3;
    public Vector3 getBallPos()
    {
        //Vector3 vector3 = ballTf.position;
        vector3 = ballTf.position;
        vector3.z = 0;
        return vector3;
    }
    public void MoveFlagSet(bool flag)
    {
        moveFlag = flag;
    }
    public void TelePort(Vector2 position)
    {
        ballPos = position;
        firstPos = ballPos;
    }
    Vector2 directionVector;
    public void MoveValueSet(Vector2 endPos)
    {
        //firstPos = new Vector2(ballTf.position.x, ballTf.position.y);
        firstPos.x = ballTf.position.x;
        firstPos.y = ballTf.position.y;
       // Vector2 directionVector =new Vector2(endPos.x - firstPos.x, endPos.y - firstPos.y);
        directionVector.x = endPos.x - firstPos.x;
        directionVector.y = endPos.y - firstPos.y;
        moveValue = directionVector.normalized;
    }
    public void MoveValueSet(Vector2 firstPos1, Vector2 endPos)
    {
        firstPos = firstPos1;
        moveValue = (endPos - firstPos1).normalized;
    }
    const string Success = "Success";
    const string failure = "failure";
    public void StopBall(bool isSuccess)
    {
        moveFlag = false;
        if (isSuccess)
        {
            FinishText.text = Success;
            if (!SceneManager.GetActiveScene().buildIndex.Equals(SceneManager.sceneCountInBuildSettings-1))
                NextButton.gameObject.SetActive(true);
            else
                NextButton.gameObject.SetActive(false);
        }
        else
        {
            FinishText.text = failure;
            NextButton.gameObject.SetActive(false);
        }
        FinishPanel.SetActive(true);
    }
    public int GetCounter()
    {
        return RemainingNum;
    }
    Vector2 currentPos;
    Vector2 collVector2;
    Vector2 incomingVector;
    Vector2 normalVector;
    Vector2 reflectVector;
    const string Block = "Block";
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Block) && !frameCollisionCheck)
        {
            frameCollisionCheck = true;
            //Vector2 currentPos = new Vector2(Ball.transform.position.x, Ball.transform.position.y);
            currentPos.x = ballTf.position.x;
            currentPos.y = ballTf.position.y;
            // 입사벡터를 알아본다. (충돌할때 충돌한 물체의 입사 벡터 노말값)
            //Vector2 collVector2 = -(firstPos - currentPos);// moveValue;
            collVector2 = -(firstPos - currentPos);
            //Vector2 incomingVector = collision.contacts[0].point - collVector2;
            incomingVector = collision.contacts[0].point - collVector2;
            incomingVector = incomingVector.normalized;
            // 충돌한 면의 법선 벡터를 구해낸다.
           // Vector2 normalVector = collision.contacts[0].normal;
            normalVector = collision.contacts[0].normal;
            // 법선 벡터와 입사벡터을 이용하여 반사벡터를 알아낸다.
            //Vector2 reflectVector = Vector2.Reflect(collVector2.normalized, normalVector); //반사각
            reflectVector = Vector2.Reflect(collVector2.normalized, normalVector); //반사각
            moveValue = reflectVector.normalized;
            firstPos = currentPos;
            RemainingNum--;
            if ((RemainingNum) < 0)
                StopBall(false);
            else
                countNum.text = (RemainingNum).ToString();
        }
    }
    
}
