using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCarSecond : MoveByTime
{
    public GetObjectCarStart getObjectCarStart;
    public List<GameObject> carObjectsStart;
    protected GameObject carObjcectSecond;
    public bool isMoveCarEndGame = true;
    public override void Start()
    {
        timeMove = 1f;
        endPosition = new Vector3(12f, -1.77f, 0);
        carObjectsStart = getObjectCarStart.carObjects;
        carObjcectSecond = carObjectsStart[1];
        StartCoroutine(moveCar(carObjcectSecond, endPosition, timeMove));
    }
    private void Update()
    {      
        MovecarCollectItem();// di chuyển xe thứ 2 khi xe chơi chạm chữ
        CheckMoveCarEndGame(); // di chuyển xe cuối game
        CheckMoveCarSecondDis();// xe vượt xe đang chơi
    }
    public IEnumerator moveCar(GameObject carObjcectSecond, Vector3 endPosition,float timeMove)
    {
        yield return new WaitForSeconds(11f);
        StartCoroutine(MoveSmoothly(carObjcectSecond, endPosition, timeMove));
    }
    public void MovecarCollectItem()
    {
        if (GameManager.Instance.IsMoveCarSecond() == true && carObjectsStart[0].transform.position.x == -12f)
        {
            CheckMoveCarTheSecond();
            GameManager.Instance.SetMoveCarSecond(false);
        }
    }
    public void CheckMoveCarTheSecond()
    {
        Vector3 currentPositionSecond = carObjcectSecond.transform.position;
        Vector3 positionTargetSecond = new Vector3(currentPositionSecond.x - 30f, currentPositionSecond.y, 0);
        timeMove = 3f;
        StartCoroutine(MoveSmoothly(carObjcectSecond, positionTargetSecond, timeMove));
    }

    public void CheckMoveCarEndGame()
    {
        if(GameManager.Instance.IsMoveTwoCarEnd()==true && isMoveCarEndGame)
        {
            isMoveCarEndGame = false;
            Vector3 currentPositionSecond = carObjcectSecond.transform.position;
            Vector3 positionTargetSecond = new Vector3(currentPositionSecond.x + 30f, currentPositionSecond.y, 0);
            timeMove = 2f;
            StartCoroutine(MoveSmoothly(carObjcectSecond, positionTargetSecond, timeMove));
        }
    }

    public void CheckMoveCarSecondDis()
    {
        if (GameManager.Instance.IsMoveCarSecondDis() == true)
        {
            if (carObjcectSecond.transform.position.x < 0 && carObjectsStart[0].transform.position.x>0)
            {
                Vector3 currentPositionSecond = carObjcectSecond.transform.position;
                Vector3 positionTargetSecond = new Vector3(currentPositionSecond.x + 30f, currentPositionSecond.y, 0);
                timeMove = 2f;
                StartCoroutine(MoveSmoothly(carObjcectSecond, positionTargetSecond, timeMove));
            }
            GameManager.Instance.SetMoveCarSecondDis(false);
        }
    }
}
