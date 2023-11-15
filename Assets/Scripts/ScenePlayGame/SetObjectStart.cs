using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectStart : MonoBehaviour
{
    public string clickObjectName;
    // Start is called before the first frame update
    void Start()
    {
        clickObjectName = GameManager.Instance.GetClickedObjectName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
