using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCarOne: MoveByTime
{
    public GetObjectCarStart getObjectCarStart;
    public List<GameObject> carObjectsStart;
    protected GameObject carObjcectOne;
    protected Vector3 targetPosition;
    protected bool isMoveCarCollectLetter = true;
    protected bool isMoveCarEndOne = true;

    public override void Start()
    {
        timeMove = 1.35f;
        endPosition = new Vector3(12f, -0.2f, 0);
        carObjectsStart = getObjectCarStart.carObjects;
        carObjcectOne = carObjectsStart[0];
        StartCoroutine(moveCar(carObjcectOne, endPosition, timeMove));
    }
    private void Update()
    {
        MoveCarCollectLetter();
        MoveCarEndGame();
        MoveCarDis();
    }

    public IEnumerator moveCar(GameObject carObjcectOne, Vector3 endPosition, float timeMove)
    {
        yield return new WaitForSeconds(11f);
        StartCoroutine(MoveSmoothly(carObjcectOne, endPosition, timeMove));
        GameManager.Instance.SetChangeLandInstruction(true);
        GameManager.Instance.SetClickEabled(true);
    }

    public void MoveCarCollectLetter()
    {
        if(GameManager.Instance.IsMoveCarPlayer()==true && GameManager.Instance.IsMoveCarOnehappy()==true)
        {
            targetPosition = new Vector3(-12f, carObjcectOne.transform.position.y, 0);
            timeMove = 3f;
            StartCoroutine(MoveSmoothly(carObjcectOne, targetPosition, timeMove));
            GameManager.Instance.SetMoveCarOnehappy(false);
        }
    }

    public void MoveCarEndGame()
    {
        if (GameManager.Instance.IsMoveTwoCarEnd() == true && isMoveCarEndOne)
        {
            isMoveCarEndOne = false;
            targetPosition = new Vector3(12f, carObjcectOne.transform.position.y, 0);
            timeMove = 2f;
            StartCoroutine(MoveSmoothly(carObjcectOne, targetPosition, timeMove));
        }
    }

    public void MoveCarDis()
    {
        if (GameManager.Instance.IsMoveCarOneDis() == true)
        {
            if(carObjcectOne.transform.position.x < 0)
            {
                StartCoroutine(MoveToTarget(carObjcectOne, 25f));
            }
            GameManager.Instance.SetMoveCarOneDis(false);

        }
    }

    public IEnumerator MoveToTarget(GameObject targetObject, float distanceToMove)
    {
        Vector3 initialPosition = targetObject.transform.position;
        Vector3 targetPosition = initialPosition + new Vector3(distanceToMove, 0, 0);
        float startTime = Time.time;
        float journeyLength = Vector3.Distance(initialPosition, targetPosition);

        float speed = 15.0f;
        float duration = journeyLength / speed;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float fractionOfJourney = elapsedTime / duration;
            targetObject.transform.position = Vector3.Lerp(initialPosition, targetPosition, fractionOfJourney);

            elapsedTime += Time.deltaTime;

            // Chờ một frame trước khi kiểm tra điều kiện kết thúc
            yield return null;
        }

        // Đảm bảo đối tượng đến đúng vị trí cuối cùng
        targetObject.transform.position = targetPosition;
    }
}
