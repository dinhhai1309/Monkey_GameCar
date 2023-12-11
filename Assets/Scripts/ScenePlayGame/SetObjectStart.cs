using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectStart : ChangeAnimation
{
    public string clickObjectName;
    public string firstObjectCar;
    public string secondObjectCar;
    public string thirdObjectCar;
    public string firstObjectCarStart;
    public string secondObjectCarStart;
    public string thirdObjectCarStart;
    public GetPositionStart getPositionStart; // class để lấy vị trí của scene Play Game
    public GetObjectCarStart getObjectCarStart;
    public bool checkAnimationName=true;
    public List<GameObject> carObjectsStart;

    // Start is called before the first frame update
    void Start()
    {
        clickObjectName = GameManager.Instance.GetClickedObjectName();
        firstObjectCar = "Xe hong_Chon";
        secondObjectCar = "Xe xanh_Chon";
        thirdObjectCar = "Xe cam_Chon";
        firstObjectCarStart = "Xe hong_0";
        secondObjectCarStart = "Xe xanh_0";
        thirdObjectCarStart = "Xe cam_0";
        carObjectsStart = getObjectCarStart.carObjects;
    }

    // Update is called once per frame
    void Update()
    {
        if(checkAnimationName == true)
        {

            checkAnimationName = false;
            if(clickObjectName == nameAnimationFirst())
            {
                clickObjectName = firstObjectCarStart;
                ChangeAnimationObject(carObjectsStart[2],clickObjectName);
                ChangeAnimationObject(carObjectsStart[1], secondObjectCarStart);
                ChangeAnimationObject(carObjectsStart[0], thirdObjectCarStart);
            }
            else if(clickObjectName == nameAnimationSecond())
            {
                clickObjectName = secondObjectCarStart;
                ChangeAnimationObject(carObjectsStart[2], clickObjectName);
                ChangeAnimationObject(carObjectsStart[1], thirdObjectCarStart);
                ChangeAnimationObject(carObjectsStart[0], firstObjectCarStart);
            }
            else if (clickObjectName == nameAnimationThird())
            {
                clickObjectName = thirdObjectCarStart;
                ChangeAnimationObject(carObjectsStart[2], clickObjectName);
                ChangeAnimationObject(carObjectsStart[1], secondObjectCarStart);
                ChangeAnimationObject(carObjectsStart[0], firstObjectCarStart);
            }
        }
    }

    public string nameAnimationFirst()
    {
        return firstObjectCar;
    }

    public string nameAnimationSecond()
    {
        return secondObjectCar;
    }

    public string nameAnimationThird()
    {
        return thirdObjectCar;
    }
}
