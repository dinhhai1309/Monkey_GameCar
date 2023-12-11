using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCarPlayer : MoveByTime
{
    public GetObjectCarStart getObjectCarStart;
    public List<GameObject> carObjectsStart;
    protected GameObject objectcarPlayer;
    public Vector3 targetPosition;
    public Vector3 startPosition;
    public bool isMoveCar= true;
    public float timeMoveCar;

    public override void Start()
    {
        carObjectsStart = getObjectCarStart.carObjects;
        objectcarPlayer = carObjectsStart[2];
    }

    private void Update()
    {
        if (GameManager.Instance.IsMoveCarPlayer() == true && GameManager.Instance.IsMoveCarPlayerSecond() == true)
        {          
            GameManager.Instance.SetChangeAnimationSpeedUp(true);
            StartMovecar(1.5f);
            StartCoroutine(MoveReturnCarPlayer(1.5f));
            GameManager.Instance.SetMoveCarPlayerSecond(false);
        }
        if(GameManager.Instance.IsCheckColliderPower() == true && GameManager.Instance.IsMoveCarColliderPower() == true)
        {
            StartCoroutine(DelayThird());
            GameManager.Instance.SetMoveCarColliderPower(false);
        }
    }
    public IEnumerator DelayThird()
    {
        yield return new WaitForSeconds(2f);
        StartMovecar(1f);
        GameManager.Instance.SetChangeAnimationPlusSpeed(true);
        yield return new WaitForSeconds(3f);
        GameManager.Instance.SetEndGame(true);
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine(MoveSmoothly(objectcarPlayer, targetPosition+ new Vector3(15f,0,0), 1f));
        GameManager.Instance.SetMoveTwoCarEnd(true); // class movecarOne, Movecartwo

    }
    public void StartMovecar(float timeMoveCar)
    {
        startPosition = objectcarPlayer.transform.position;
        targetPosition = new Vector3(0, objectcarPlayer.transform.position.y, 0);
        StartCoroutine(MoveSmoothly(objectcarPlayer, targetPosition, timeMoveCar));
        StartCoroutine(ChangeAnimationCarPlayer());
    }
    public IEnumerator ChangeAnimationCarPlayer()
    {
        yield return new WaitForSeconds(timeMoveCar);
        GameManager.Instance.SetChangeAnimationCarPlayer(true);
        yield return new WaitForSeconds(1f);
        GameManager.Instance.SetChangeAnimationLoop(true);
    }

    public IEnumerator MoveReturnCarPlayer(float timeMovecar)
    {
        yield return new WaitForSeconds(4f);
        StartCoroutine(MoveSmoothly(objectcarPlayer, startPosition, timeMovecar));
        GameManager.Instance.SetChangeAnimationNomarl(true);
    }

}
