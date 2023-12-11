using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLaneInstruction : MoveByTime
{
    public GetLane getLane;
    public List<GameObject> laneObjects;
    public GetPositionStart getPositionStart;
    public GetObjectCarStart getObjectCar;
    public List<GameObject> objectCars;
    public List<Vector3> positionCarStart;

    public Vector3 previousCarPlayerPosition;
    public Vector3 positionCarSecond;
    public GameObject carPlayer;
    public SoundTapHere soundTapHere;
    // Start is called before the first frame update
    public override void Start()
    {
        laneObjects = getLane.laneObjects;
        positionCarStart = getPositionStart.carPositionsStart;
        objectCars = getObjectCar.carObjects;
        carPlayer = getObjectCar.carObjects[2];
        previousCarPlayerPosition = carPlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
        if (GameManager.Instance.IsClickEabled() == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleMouseClick();
            }
        }
    }
    public void UpdatePosition()
    {
        positionCarSecond = new Vector3(objectCars[1].transform.position.x, previousCarPlayerPosition.y, 0);
    }
    void HandleMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null)
        {
            GameObject clickedObject = hit.collider.gameObject;

            // Kiểm tra xem đối tượng có thuộc tính laneObjects không
            if (laneObjects.Contains(clickedObject))
            {
                int objectIndex = laneObjects.IndexOf(clickedObject);
                if (objectIndex == 1)
                {
                    StartCoroutine(MoveSmoothly(carPlayer, positionCarStart[1], 0.25f));
                    GameManager.Instance.SetPhonicFirst(true);
                    ChangeVariable();
                }
            }
        }
    }

    public void ChangeVariable()
    {
        GameManager.Instance.SetSoundGuilding(true);
        GameManager.Instance.SetSoundTapHere(false);
        GameManager.Instance.SetHandEnabled(true);
        GameManager.Instance.SetShowText(true);
    }
}
