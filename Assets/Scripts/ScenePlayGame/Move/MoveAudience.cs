using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAudience : MoveBySpeed
{
    public GameObject Audience;
    public float speedLetter;
    protected float distanceToMove;
    public Vector3 startAudience;
    public bool isMoveAudience = true;
    void Start()
    {
        speedLetter = 10f;
        distanceToMove = -25f;
        startAudience = Audience.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsMoveAudience()==true && GameManager.Instance.IsCheckMoveAudience()== true)
        {
            StartCoroutine(MoveToTarget(Audience, distanceToMove, speedLetter));
            GameManager.Instance.SetCheckMoveAudience(false);
            StartCoroutine(ResetPositionAudience());
        }
    }

    public IEnumerator ResetPositionAudience()
    {
        yield return new WaitForSeconds(5f);
        GameManager.Instance.SetCheckMoveAudience(false);
        Audience.transform.position = startAudience;
        GameManager.Instance.SetColliderLetter(false);
    }
}
