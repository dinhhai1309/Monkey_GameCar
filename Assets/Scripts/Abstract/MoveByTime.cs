using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveByTime : MonoBehaviour
{
    public Vector3 endPosition;
    public float timeMove;
    public abstract void Start();

    public IEnumerator MoveSmoothly(GameObject carObject, Vector3 targetPosition, float timeToMove)
    {
        float elapsedTime = 0;

        Vector3 startingPos = carObject.transform.position;

        while (elapsedTime < timeToMove)
        {
            carObject.transform.position = Vector3.Lerp(startingPos, targetPosition, elapsedTime / timeToMove);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        carObject.transform.position = targetPosition; // Đảm bảo đến đúng vị trí cuối cùng
    }


}
