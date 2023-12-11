using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePositionCar : MonoBehaviour
{
    public GetObjectCarStart getObjectCarStart;
    public GetPositionStart getPositionStart;
    public List<GameObject> listObjectCars;
    public List<Vector3> listPositionCars;
    public List<float> usedYCoordinates;

    // Start is called before the first frame update
    void Start()
    {
        UpdatePositions();
    }

    // Update is called once per frame
    void Update()
    {
        // Gọi hàm để kiểm tra và đổi vị trí nếu cần
        CheckAndFixObjectCarsY();
    }

    // Kiểm tra và đổi vị trí nếu cần
    void CheckAndFixObjectCarsY()
    {
        if (listObjectCars[2].transform.position.y == usedYCoordinates[0])
        {
            // Thay đổi tọa độ y của xe thứ 0 và xe thứ 1
            listObjectCars[0].transform.position = new Vector3(listObjectCars[0].transform.position.x, usedYCoordinates[1], listObjectCars[0].transform.position.z);
            listObjectCars[1].transform.position = new Vector3(listObjectCars[1].transform.position.x, usedYCoordinates[2], listObjectCars[1].transform.position.z);
        }
        else if (listObjectCars[2].transform.position.y == usedYCoordinates[1])
        {
            // Thay đổi tọa độ y của xe thứ 0 và xe thứ 1
            listObjectCars[0].transform.position = new Vector3(listObjectCars[0].transform.position.x, usedYCoordinates[0], listObjectCars[0].transform.position.z);
            listObjectCars[1].transform.position = new Vector3(listObjectCars[1].transform.position.x, usedYCoordinates[2], listObjectCars[1].transform.position.z);
        }
        else if (listObjectCars[2].transform.position.y == usedYCoordinates[2])
        {
            // Thay đổi tọa độ y của xe thứ 0 và xe thứ 1
            listObjectCars[0].transform.position = new Vector3(listObjectCars[0].transform.position.x, usedYCoordinates[0], listObjectCars[0].transform.position.z);
            listObjectCars[1].transform.position = new Vector3(listObjectCars[1].transform.position.x, usedYCoordinates[1], listObjectCars[1].transform.position.z);
        }
    }

    // Cập nhật tọa độ ban đầu
    void UpdatePositions()
    {
        listObjectCars = getObjectCarStart.carObjects;
        listPositionCars = getPositionStart.carPositionsStart;
        GetListPositionY();
    }
    public void GetListPositionY()
    {
        foreach (var position in listObjectCars)
        {
            usedYCoordinates.Add(position.transform.position.y);
        }
    }
}
