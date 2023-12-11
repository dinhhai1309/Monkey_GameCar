using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleHand : ScaleByTime
{
    public GameObject objectHand;
    void Start()
    {
        StartCoroutine(ScaleRoutine());
    }

    IEnumerator ScaleRoutine()
    {
        while (true)
        {
            yield return StartCoroutine(ScaleObjectCar(objectHand, new Vector3(0.6f, 0.6f, 0.6f), new Vector3(0.5f, 0.5f, 0.5f), 1f));
            yield return StartCoroutine(ScaleObjectCar(objectHand, new Vector3(0.5f, 0.5f, 0.5f), new Vector3(0.6f, 0.6f, 0.6f), 1f));
        }
    }
}

