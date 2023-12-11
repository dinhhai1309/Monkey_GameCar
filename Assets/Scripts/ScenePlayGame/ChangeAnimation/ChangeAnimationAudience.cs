using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class ChangeAnimationAudience : ChangeAnimation
{
    public GetAudience getAudience;
    public List<GameObject> listAudience;
    public string audienceOrangeHappy;
    public string audiencePinkHappy;
    public string audienceBlueHappy;
    public string audienceOrangeDis;
    public string audiencePinkDis;
    public string audienceBlueDis;
    protected SkeletonAnimation skeletonAnimationOrange;
    protected SkeletonAnimation skeletonAnimationPink;
    protected SkeletonAnimation skeletonAnimationBlue;

    public void Start()
    {
        listAudience = getAudience.listAudience;

        skeletonAnimationOrange = listAudience[0].GetComponent<SkeletonAnimation>();
        skeletonAnimationPink = listAudience[1].GetComponent<SkeletonAnimation>();
        skeletonAnimationBlue = listAudience[2].GetComponent<SkeletonAnimation>();

        audienceOrangeHappy = "Orange - Happy";
        audiencePinkHappy = "Pink - Happy";
        audienceBlueHappy = "Blue - Happy";
        audienceOrangeDis = "Orange - Sad";
        audiencePinkDis = "Pink - Sad";
        audienceBlueDis = "Blue - Sad";
}
    // Update is called once per frame
    void Update()
    {
        ChangeAnimationDisapointed();
        ChangeAnimationHappy();
    }

    public void ChangeAnimationDisapointed()
    {
        if (GameManager.Instance.IsChangeAudienceDisapointed() == true)
        {
            if(skeletonAnimationOrange.AnimationName == audienceOrangeHappy)
            {
                ChangeAnimationObject(listAudience[0], audienceOrangeDis);
            }
            if (skeletonAnimationPink.AnimationName == audiencePinkHappy)
            {
                ChangeAnimationObject(listAudience[1], audiencePinkDis);
            }
            if (skeletonAnimationBlue.AnimationName == audienceBlueHappy)
            {
                ChangeAnimationObject(listAudience[2], audienceBlueDis);
            }
            GameManager.Instance.SetChangeAudienceDisapointed(false);
        }
    }

    public void ChangeAnimationHappy()
    {
        if (GameManager.Instance.IsChangeAudienceHappy() == true)
        {
            if (skeletonAnimationOrange.AnimationName == audienceOrangeDis)
            {
                ChangeAnimationObject(listAudience[0], audienceOrangeHappy);
            }
            if (skeletonAnimationPink.AnimationName == audiencePinkDis)
            {
                ChangeAnimationObject(listAudience[1],  audiencePinkHappy);
            }
            if (skeletonAnimationBlue.AnimationName == audienceBlueDis)
            {
                ChangeAnimationObject(listAudience[2], audienceBlueHappy);
            }
            GameManager.Instance.SetChangeAudienceHappy(false);
        }
    }

}
