using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public float spawnRate;
    private float timer = 0;
    public GameObject spawnObject;

    void Update()
    {
        if(GameManager.Instance.IsMoveBackground()== true)
        {
            if (GameManager.Instance.IsCheckColliderPower() == true)
            {
                if (timer < 1.4f)
                {
                    timer += Time.deltaTime;
                }
                else
                {
                    spawnCloud(spawnObject);
                }
            }
            else
            {
                if (timer < 3.5f)
                {
                    timer += Time.deltaTime;
                }
                else
                {
                    spawnCloud(spawnObject);
                }
            }
                
        }
    }

    void spawnCloud(GameObject spawnObject)
    {

        Instantiate(spawnObject, transform.position, transform.rotation);
        timer = 0;
    }
}
