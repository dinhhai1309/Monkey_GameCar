using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public abstract class ChangeAnimation : MonoBehaviour
{
    protected string nameAnimation;

    public void ChangeAnimationObject(GameObject clickObject, string nameAnimation)
    {
        SkeletonAnimation skeletonAnimation = clickObject.GetComponent<SkeletonAnimation>();
        skeletonAnimation.AnimationName = nameAnimation;
    }
}
