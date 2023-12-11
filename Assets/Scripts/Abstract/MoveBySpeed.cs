using System.Collections;
using UnityEngine;

public abstract class MoveBySpeed : MonoBehaviour
{
    public IEnumerator MoveToTarget(GameObject targetObject, float distanceToMove, float speed)
    {
        Vector3 initialPosition = targetObject.transform.position;
        Vector3 targetPosition = initialPosition + new Vector3(distanceToMove, 0, 0);

        float startTime = Time.time;
        float journeyLength = Mathf.Abs(distanceToMove); // Sử dụng Mathf.Abs để đảm bảo khoảng cách là dương

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
