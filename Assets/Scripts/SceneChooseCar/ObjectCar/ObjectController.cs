using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;


public class ObjectController : MonoBehaviour
{
    public MoveCarToMiddle moveCarToMiddle;
    public MoveCarTheSide moveCarTheSide;
    public GetPosition getPosition;
    public GetObjectCar getObjectCar;
    public List<Vector3> positionObjectCar;
    public List<GameObject> objectCar;
    public GameObject clickedObject;

    void Update()
    {
        positionObjectCar = getPosition.carPositionsStart;
        objectCar = getObjectCar.carObjects;
        CheckClickEabled();
    }
    public void CheckClickEabled()
    {
        if (GameManager.Instance.IsClickEabled() == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.Instance.SetClickEabled(false);
                HandleMouseClick();
            }
        }
    }
    void HandleMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        // Kiểm tra xem có đối tượng nào được click hay không
        if (hit.collider != null)
        {
            clickedObject = hit.collider.gameObject;
            Transform[] childObjects = clickedObject.GetComponentsInChildren<Transform>();

            // Duyệt qua từng đối tượng con
            foreach (Transform child in childObjects)
            {
                // Kiểm tra xem đối tượng con có thành phần SkeletonAnimation không
                SkeletonAnimation skeletonAnimation = child.GetComponent<SkeletonAnimation>();

                if (skeletonAnimation != null)
                {
                    // Bạn có thể sử dụng skeletonAnimation ở đây
                    string animationName = skeletonAnimation.AnimationName;
                    GameManager.Instance.SetClickedObjectName(animationName);
                    break; // Nếu bạn chỉ quan tâm đến một đối tượng con đầu tiên có SkeletonAnimation
                }
            }
            if (getObjectCar.carObjects.Contains(clickedObject))
            {
                // Lấy index của đối tượng trong danh sách
                int objectIndex = getObjectCar.carObjects.IndexOf(clickedObject);
                // Kiểm tra xem có đủ phần tử trong positionObjectCar không
                if (positionObjectCar.Count >= 2)
                {
                    // Di chuyển đối tượng đó tới vị trí thứ 2 của positionObjectCar
                    moveCarToMiddle.MoveCar(clickedObject, positionObjectCar);
                    moveCarTheSide.MoveCar(objectCar[1], clickedObject.transform.position);
                }
                else
                {
                    Debug.LogError("Không đủ phần tử trong positionObjectCar.");
                }
            }
        }
    }

}