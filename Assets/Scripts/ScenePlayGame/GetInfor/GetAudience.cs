using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAudience : MonoBehaviour
{
    public List<GameObject> listAudience;
    public void Awake()
    {
        getLaneObjects();
    }

    public void getLaneObjects()
    {
        // Lấy tất cả các đối tượng có tag "carObject" và đặt chúng vào danh sách carObjects
        listAudience = new List<GameObject>(GameObject.FindGameObjectsWithTag("Audience"));
    }
}
