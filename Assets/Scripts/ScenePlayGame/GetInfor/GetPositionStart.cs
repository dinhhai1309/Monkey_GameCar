using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPositionStart : MonoBehaviour
{
    public GetObjectCarStart getObjectCarStart;
    public List<Vector3> carPositionsStart = new List<Vector3>();
    public List<GameObject> getObjectCar = new List<GameObject>();

    public void Start()
    {
        getObjectCar = getObjectCarStart.carObjects;
        UpdateCarPositions();
    }

    public void UpdateCarPositions()
    {
        foreach (GameObject carObject in getObjectCar)
        {
            carPositionsStart.Add(carObject.transform.position);
        }
    }
}
