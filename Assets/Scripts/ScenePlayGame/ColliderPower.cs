using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPower : MonoBehaviour
{
    public GameObject objectPower;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsCheckColliderPower() == true)
        {
            objectPower.SetActive(false);
        }
    }
}
