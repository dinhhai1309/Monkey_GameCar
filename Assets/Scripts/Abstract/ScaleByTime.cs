using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleByTime : MonoBehaviour
{
    public Vector3 startScale;
    public Vector3 targetScale;
    public IEnumerator ScaleObjectCar(GameObject scaleObject, Vector3 fromScale, Vector3 toScale, float scaleDuration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < scaleDuration)
        {
            scaleObject.transform.localScale = Vector3.Lerp(fromScale, toScale, elapsedTime / scaleDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        scaleObject.transform.localScale = toScale;
    }

}
