using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPosition : MonoBehaviour
{
    public List<Vector3> carPositionsStart = new List<Vector3>();
    public RandomCar randomCar;
    public GetObjectCar getObjectCar;
    public List<GameObject> objectsCar;
    public void Start()
    {
        objectsCar = getObjectCar.carObjects;
        StartCoroutine(DelayTime());
    }

    public void UpdateCarPositions()
    {
        // Lặp qua danh sách các đối tượng và lấy vị trí của chúng
        foreach (GameObject carObject in objectsCar)
        {
            carPositionsStart.Add(carObject.transform.position);
        }
    }
    public IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(3f);
        UpdateCarPositions();
    }
}
