using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackTwo : MoveBySpeed
{
    public float speedBackTwo;
    protected float distanceToMove;
    public GameObject BackTwo;
    public bool isMove;

    // Start is called before the first frame update
    void Start()
    {
        speedBackTwo = 3.2f;
        distanceToMove = -40f;
        isMove = true;
}

public void Update()
    {
        if (GameManager.Instance.IsMoveBackground() == true && isMove == true)
        {
            if (GameManager.Instance.IsCheckColliderPower() == true)
            {
                StartCoroutine(MoveToTarget(BackTwo, distanceToMove, speedBackTwo+ 5f));
            }
            else
            {
                StartCoroutine(MoveToTarget(BackTwo, distanceToMove, speedBackTwo));
            }
            isMove = false;
        }
    }
}
