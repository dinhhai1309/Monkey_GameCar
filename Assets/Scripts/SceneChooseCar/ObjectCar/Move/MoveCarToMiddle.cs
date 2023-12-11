using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCarToMiddle : MoveByTime
{
    public ScaleClickObject ScaleClickObject;
    public LightAppear lightAppear;
    public override void Start()
    {

    }

    public void MoveCar(GameObject carObject, List<Vector3> carPositions)
    {
        timeMove = 1f;
        endPosition = carPositions[1];
        StartCoroutine( Move(carObject, timeMove));
    }

    public IEnumerator Move(GameObject carObject, float timeMoveCar)
    {
        StartCoroutine(MoveSmoothly(carObject, endPosition, timeMoveCar));
        yield return new WaitForSeconds(1f);
        ScaleClickObject.ScaleObject(carObject);
        GameManager.Instance.SetHiddenTextTap(true);
        StartCoroutine(lightAppear.IsLightObject());
        GameManager.Instance.SetPlaySoundChooseSuccess(true);
    }
}
