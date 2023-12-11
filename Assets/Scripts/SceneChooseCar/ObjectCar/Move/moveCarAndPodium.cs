using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCarAndPodium : MoveByDistance
{
    [SerializeField] public GetObjectCar getObjectCar; // Thêm tham chiếu đến lớp chứa danh sách carObjects
    [SerializeField] public GetChildrenObjectCar getChildrenObjectCar; // Thêm tham chiếu đến lớp chứa danh sách carObjects
    protected float distanceCarAndPodium;
    protected float distanceCar;
    public List<GameObject> carObject;
    public List<GameObject> carChildrenObject;
    public int currentCarIndex = 0;
    public bool isMoving = true;
    void Awake()
    {
        distanceCarAndPodium = 5f;
        distanceCar = 6f;
    }
    private void Start()
    {
        carObject = getObjectCar.carObjects;
        carChildrenObject = getChildrenObjectCar.carChildrenObjects;
        if (isMoving)
        {
            StartCoroutine(MoveCarsSequentially());           
        }
    }
    public IEnumerator MoveCarsSequentially()
    {
        int totalCars = carObject.Count;
        int currentCarIndex = 0;
        while (currentCarIndex < totalCars)
        {
            StartCoroutine( MoveToTarget(carObject[currentCarIndex], distanceCarAndPodium));
            MoveChildrenCars(currentCarIndex);
            yield return new WaitForSeconds(0.5f);
            currentCarIndex++;
            // Kiểm tra khi nào đã di chuyển tất cả các xe và reset lại currentCarIndex
            if (currentCarIndex >= totalCars)
            {
                isMoving = false;
                GameManager.Instance.SetScaleText(true);
                GameManager.Instance.SetPlaySoundText(true);
            }
        }
    }

    public void MoveChildrenCars(int currentCarIndex)
    {
        StartCoroutine(MoveToTarget(carChildrenObject[currentCarIndex], distanceCar));
        StartCoroutine(DelayOneTime(currentCarIndex));
    }

    public IEnumerator DelayOneTime(int currentCarIndex)
    {
        yield return new WaitForSeconds(1.3f);
        GameManager.Instance.SetPlaySoundPodium(true);
        StartCoroutine(MoveToTarget(carChildrenObject[currentCarIndex], -1f));
    }
}

