using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveByDistance : MonoBehaviour
{
    public IEnumerator MoveToTarget(GameObject targetObject, float distanceToMove)
    {
        Vector3 initialPosition = targetObject.transform.position;
        Vector3 targetPosition = initialPosition + new Vector3(0, distanceToMove, 0);

        float startTime = Time.time;
        float journeyLength = Vector3.Distance(initialPosition, targetPosition);

        float speed = 5.0f;
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


