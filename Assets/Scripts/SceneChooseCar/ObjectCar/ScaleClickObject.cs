using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleClickObject : ScaleByTime
{
    public void ScaleObject(GameObject carObject)
    {
        startScale = carObject.transform.localScale;
        targetScale = new Vector3(1.3f, 1.5f, 1.5f);
        StartCoroutine(ScaleObjectCar(carObject,startScale, targetScale,0.5f));
    }
}
