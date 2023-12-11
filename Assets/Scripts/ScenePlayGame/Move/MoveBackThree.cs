using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackThree : MoveBySpeed
{
    public float speedBackThree;
    protected float distanceToMove;
    public GameObject BackThree;
    public bool isMove;

    // Start is called before the first frame update
    void Start()
    {
        speedBackThree = 2.8f;
        distanceToMove = -40f;
        isMove = true;

    }

    public void Update()
    {
        if(GameManager.Instance.IsMoveBackground()== true && isMove == true)
        {
            if(GameManager.Instance.IsCheckColliderPower() == true)
            {
                StartCoroutine(MoveToTarget(BackThree, distanceToMove, speedBackThree + 6f));
            }
            else
            {
                StartCoroutine(MoveToTarget(BackThree, distanceToMove, speedBackThree));
            }
            isMove = false;
        }
    }
}
