using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLane : MonoBehaviour
{
    public List<GameObject> laneObjects;
    public void Awake()
    {
        getLaneObjects();
    }

    public void getLaneObjects()
    {
        // Lấy tất cả các đối tượng có tag "carObject" và đặt chúng vào danh sách carObjects
        laneObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Lane"));
    }
}
