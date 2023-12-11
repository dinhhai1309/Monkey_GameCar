using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackOne : MoveBySpeed
{
    public float speedBackOne;
    protected float distanceToMove;
    public GameObject BackOne;
    public bool isMove ;
    // Start is called before the first frame update
    void Start()
    {
        speedBackOne = 4f;
        distanceToMove = -40f;
        isMove = true;
    }
    public void Update()
    {
        if (GameManager.Instance.IsMoveBackground() == true && isMove==true)
        {
            if(GameManager.Instance.IsCheckColliderPower() == true)
            {
                StartCoroutine(MoveToTarget(BackOne, distanceToMove, speedBackOne+5f));
            }
            else
            {
                StartCoroutine(MoveToTarget(BackOne, distanceToMove, speedBackOne));
            }
            isMove = false;
        }
    }
}
