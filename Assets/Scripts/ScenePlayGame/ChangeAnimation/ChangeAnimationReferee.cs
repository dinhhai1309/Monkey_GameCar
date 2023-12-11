using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class ChangeAnimationReferee : MonoBehaviour
{
    public GameManager gameManager;
    // Update is called once per frame
    public void Start()
    {
        StartCoroutine(PerformAction());
    }
    public IEnumerator PerformAction()
    {
        yield return new WaitForSeconds(9f);
        SkeletonAnimation skeletonAnimation = GetComponent<SkeletonAnimation>();
        skeletonAnimation.loop = false;
        skeletonAnimation.AnimationName = "Referee - Go";
        yield return new WaitForSeconds(2f);
        skeletonAnimation.AnimationName = "Referee - Idle";
        GameManager.Instance.SetMoveBackground(true);
    }
}
