using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCarTheSide : MoveByTime
{
    protected Vector3 TargetPosition;
    public override void Start()
    {
        
    }
    public void MoveCar(GameObject carObject, Vector3 endPosition)
    {
        timeMove = 1f;
        TargetPosition = endPosition;
        Move(carObject, TargetPosition, timeMove);
    }

    public void Move(GameObject carObject,Vector3 endPosition, float timeMoveCar)
    {
        StartCoroutine(MoveSmoothly(carObject, endPosition, timeMoveCar));
    }
}
