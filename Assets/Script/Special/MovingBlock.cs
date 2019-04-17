using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour {
    public GameObject target1;
    public GameObject target2;
    public GameObject movingBlock;
    public float speed;
    bool a = true;
    private Transform T1transform;
    private Transform T2transform;
    private Transform Mtransform;
    void Awake()
    {
        T1transform = target1.transform;
        T2transform = target2.transform;
        Mtransform = movingBlock.transform;
    }
    void FixedUpdate() {
        if (a == true)
        {
            Mtransform.position =
          Vector3.MoveTowards(Mtransform.position, T1transform.position, speed * Time.deltaTime);
            if (Mtransform.position == T1transform.position)
                a = false;
        }
        else if (a == false)
        {
            Mtransform.position =
          Vector3.MoveTowards(Mtransform.position, T2transform.position, speed * Time.deltaTime);
            if (Mtransform.position == T2transform.position)
                a = true;
        }
    }
}
