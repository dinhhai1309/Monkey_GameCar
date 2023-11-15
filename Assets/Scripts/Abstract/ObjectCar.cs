using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectCar : MoveByTime
{
    public Vector3 scaleObject;
    public  void Awake()
    {
        //scaleObject = new Vector3(0.78f,1f,1f);
    }

    public virtual void ScaleObject()
    {
        transform.localScale = scaleObject;
    }
}
