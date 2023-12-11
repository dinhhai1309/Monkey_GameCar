using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class ChangeAnimationCarPlayer : MonoBehaviour
{
    public string objectCarPlayer;
    public string firstObjectCar;
    public string secondObjectCar;
    public string thirdObjectCar;
    public string firstObjectCarStart;
    public string secondObjectCarStart;
    public string thirdObjectCarStart;
    public string firstNameLoop;
    public string secondNameLoop;
    public string thirdNameLoop;
    public string firstNamePlusSpeed;
    public string secondNamePlusSpeed;
    public string thirdNamePlusSpeed;
    public GetPositionStart getPositionStart;
    public GetObjectCarStart getObjectCarStart;
    public List<GameObject> carObjectsStart;

    public bool checkAnimationSpeedUp = true;
    public bool checkAnimationLoop = true;
    public bool checkAnimationNormal = true;
    public bool checkAnimationPlusSpeed = true;


    void Start()
    {
        carObjectsStart = getObjectCarStart.carObjects;
        firstObjectCar = "Xe hong_0";
        secondObjectCar = "Xe xanh_0";
        thirdObjectCar = "Xe cam_0";

        firstObjectCarStart = "Xe hong_2";
        secondObjectCarStart = "Xe xanh_2";
        thirdObjectCarStart = "Xe cam_2";

        firstNameLoop = "Xe hong_1-2";
        secondNameLoop = "Xe xanh_1-2";
        thirdNameLoop = "Xe cam_1-2";


        firstNamePlusSpeed = "Xe hong_3";
        secondNamePlusSpeed = "Xe xanh_3";
        thirdNamePlusSpeed = "Xe cam_3";
    }

    void Update()
    {
        StartCoroutine(getNameAnimation());
        ChangeAnimationSpeedUP();
        ChangeAnimationLoop();
        ChangeAnimationNormal();
        ChangeAnimationPlusSpeed();

    }

    // đổi animation khi tăng tốc(ăn chữ)
    public void ChangeAnimationSpeedUP()
    {
        if (checkAnimationSpeedUp == true)
        {
            if (objectCarPlayer == firstObjectCar)
            {
                if (GameManager.Instance.IsChangeAnimationSpeedUp() == true)
                {
                    GameManager.Instance.SetChangeAnimationSpeedUp(false);
                    ChangeAnimationObject(carObjectsStart[2], firstObjectCarStart);
                }
            }
            else if (objectCarPlayer == secondObjectCar)
            {
                if (GameManager.Instance.IsChangeAnimationSpeedUp() == true)
                {
                    GameManager.Instance.SetChangeAnimationSpeedUp(false);
                    ChangeAnimationObject(carObjectsStart[2], secondObjectCarStart);
                }
            }
            else if (objectCarPlayer == thirdObjectCar)
            {
                if (GameManager.Instance.IsChangeAnimationSpeedUp() == true)
                {
                    GameManager.Instance.SetChangeAnimationSpeedUp(false);
                    ChangeAnimationObject(carObjectsStart[2], thirdObjectCarStart);
                }
            }
        }
    }

    // đổi animation đèn nhấp nháy
    public void ChangeAnimationLoop()
    {
        if (GameManager.Instance.IsChangeAnimationCarPlayer() == true)
        { 
            if (objectCarPlayer == firstObjectCarStart)
            {
                if (GameManager.Instance.IsChangeAnimationLoop() == true)
                {
                    GameManager.Instance.SetChangeAnimationLoop(false);
                    ChangeAnimationObject(carObjectsStart[2], firstNameLoop);
                }
            }
           if (objectCarPlayer == secondObjectCarStart)
            {
                if (GameManager.Instance.IsChangeAnimationLoop() == true)
                {
                    GameManager.Instance.SetChangeAnimationCarPlayer(false);
                    ChangeAnimationObject(carObjectsStart[2], secondNameLoop);
                }
            }
            if (objectCarPlayer == thirdObjectCarStart)
            {
                if (GameManager.Instance.IsChangeAnimationLoop() == true)
                {
                    GameManager.Instance.SetChangeAnimationCarPlayer(false);
                    ChangeAnimationObject(carObjectsStart[2], thirdNameLoop);
                }
            }
        }
    }

    // đổi animation lùi về vị trí ban đầu(animation bình thường)
    public void ChangeAnimationNormal()
    {
        if (checkAnimationNormal == true)
        {
            if (objectCarPlayer == firstNameLoop)
            {
                if (GameManager.Instance.IsChangeAnimationNomarl() == true)
                {
                    GameManager.Instance.SetChangeAnimationNomarl(false);
                    ChangeAnimationObject(carObjectsStart[2], firstObjectCar);
                }
            }
            else if (objectCarPlayer == secondNameLoop)
            {
                if (GameManager.Instance.IsChangeAnimationNomarl() == true)
                {
                    GameManager.Instance.SetChangeAnimationNomarl(false);
                    ChangeAnimationObject(carObjectsStart[2], secondObjectCar);
                }
            }
            else if (objectCarPlayer == thirdNameLoop)
            {
                if (GameManager.Instance.IsChangeAnimationNomarl() == true)
                {
                    GameManager.Instance.SetChangeAnimationNomarl(false);
                    ChangeAnimationObject(carObjectsStart[2], thirdObjectCar);
                }
            }
        }
    }
    public void ChangeAnimationPlusSpeed()
    {
        if (checkAnimationPlusSpeed == true)
        {
            if (objectCarPlayer == firstObjectCar)
            {
                if (GameManager.Instance.IsChangeAnimationPlusSpeed() == true)
                {
                    checkAnimationPlusSpeed = false;
                    ChangeAnimationObject(carObjectsStart[2], firstNamePlusSpeed);
                }
            }
            else if (objectCarPlayer == secondObjectCar)
            {
                if (GameManager.Instance.IsChangeAnimationPlusSpeed() == true)
                {
                    checkAnimationPlusSpeed = false;
                    ChangeAnimationObject(carObjectsStart[2], secondNamePlusSpeed);
                }
            }
            else if (objectCarPlayer == thirdObjectCar)
            {
                if (GameManager.Instance.IsChangeAnimationPlusSpeed() == true)
                {
                    checkAnimationPlusSpeed = false;
                    ChangeAnimationObject(carObjectsStart[2], thirdNamePlusSpeed);
                }
            }
        }
    }
    public IEnumerator getNameAnimation()
    {
        yield return null;
        SkeletonAnimation skeletonAnimation = carObjectsStart[2].GetComponent<SkeletonAnimation>();
        objectCarPlayer = skeletonAnimation.AnimationName;
    }

    public void ChangeAnimationObject(GameObject clickObject, string nameAnimation)
    {
        SkeletonAnimation skeletonAnimation = clickObject.GetComponent<SkeletonAnimation>();
        skeletonAnimation.AnimationName = nameAnimation;
    }
}

