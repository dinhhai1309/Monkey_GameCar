using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFlag : MoveByTime
{
    public GameObject flagObject;
    // Start is called before the first frame update
    public override void Start()
    {
        endPosition = new Vector3(5.08f,-1.43f,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.IsMoveFlag() == true){
            StartCoroutine(MoveSmoothly(flagObject, endPosition, timeMove));
            GameManager.Instance.SetMoveFlag(false);
        }
    }
}
