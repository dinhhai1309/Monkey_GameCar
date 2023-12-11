using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePower : MoveBySpeed
{
    public GameObject objectPower;
    public float speed;
    public float distanceToMove;
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsCheckCompletePhonic() == true) // class CheckColliderLetter
        {
            GameManager.Instance.SetCheckCompletePhonic(false);
            speed = 4f;
            distanceToMove = -20f;
            StartCoroutine(MoveToTarget(objectPower, distanceToMove, speed));
        }
    }
}
