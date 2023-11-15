using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAppear : MonoBehaviour
{
    [SerializeField] public GameObject LightObject;
    public void Start()
    {
        LightObject.SetActive(false);
    }
    public void Update()
    {
    }

    public IEnumerator IsLightObject()
    {
        while (true)
        {            
            LightObject.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            LightObject.SetActive(false);
            yield return new WaitForSeconds(0.3f);

        }
    }
}
