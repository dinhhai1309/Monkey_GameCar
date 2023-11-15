using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class RandomCar : MonoBehaviour
{
    public GetChildrenObjectCar getChildrenObjectCar;

    // Danh sách tên animation
    private List<string> animationNames = new List<string> { "Xe cam_Chon", "Xe hong_Chon", "Xe xanh_Chon" };

    void Start()
    {
        RandomizeCars();
    }

    void RandomizeCars()
    {
        if (getChildrenObjectCar.carChildrenObjects.Count > 0 && animationNames.Count > 0)
        {
            // Tạo một bản sao của danh sách tên animation để tránh xóa phần tử từ danh sách gốc
            List<string> availableAnimations = new List<string>(animationNames);

            foreach (GameObject carObject in getChildrenObjectCar.carChildrenObjects)
            {
                // Kiểm tra nếu còn animation nào khả dụng
                if (availableAnimations.Count > 0)
                {
                    // Random index cho tên animation
                    int randomIndex = Random.Range(0, availableAnimations.Count);

                    // Lấy tên animation từ danh sách
                    string animationName = availableAnimations[randomIndex];

                    // Gán animation cho xe
                    SkeletonAnimation skeletonAnimation = carObject.GetComponent<SkeletonAnimation>();
                    skeletonAnimation.AnimationState.SetAnimation(0, animationName, true);

                    // Loại bỏ animation đã sử dụng khỏi danh sách khả dụng
                    availableAnimations.RemoveAt(randomIndex);
                }
                else
                {
                    Debug.LogWarning("Đã sử dụng hết tất cả các animation.");
                    break;
                }
            }
        }
        else
        {
            Debug.LogError("Không có xe hoặc animation để random.");
        }
    }
}
