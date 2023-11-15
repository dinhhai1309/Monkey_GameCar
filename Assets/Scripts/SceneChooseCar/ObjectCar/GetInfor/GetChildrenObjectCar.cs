using System.Collections.Generic;
using UnityEngine;

public class GetChildrenObjectCar : MonoBehaviour
{
    public List<GameObject> carChildrenObjects = new List<GameObject>();
    public RandomCar randomCar;
    public moveCarAndPodium moveCarAndPodium;

    void Awake()
    {
        getCar();
    }

    public void UpdateCarObjects()
    {
        carChildrenObjects.Clear();
        carChildrenObjects.AddRange(GameObject.FindGameObjectsWithTag("CarChildren"));
        moveCarAndPodium.carChildrenObject = carChildrenObjects;
    }

    // Gọi hàm UpdateCarObjects khi cần cập nhật danh sách
    public void getCar()
    {
        UpdateCarObjects();
    }
}
