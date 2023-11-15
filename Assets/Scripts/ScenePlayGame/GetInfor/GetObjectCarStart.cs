using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObjectCarStart : MonoBehaviour
{
    public List<GameObject> carObjects;
    public void Start()
    {
        getCarObjects();
    }

    public void getCarObjects()
    {
        // Lấy tất cả các đối tượng có tag "carObject" và đặt chúng vào danh sách carObjects
        carObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("carObject"));
    }
}
