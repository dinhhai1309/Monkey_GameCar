using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MoveByTime
{
    public GetLane getLane;
    public List<GameObject> laneObjects;

    public GetPositionStart getPositionStart;
    public List<Vector3> positionCarStart;

    public SetRandomPositionPhonic setRandomPositionPhonic;
    public List<Vector3> startPositionLetter;
    public GetObjectCarStart getObjectCar;
    public GameObject carPlayer;
    public GetLetter getLetter;
    public List<GameObject> listLetter;
    public Vector3 positionCurrentLetter;
    public Vector3 positionCurrentLetterSecond;
    public Vector3 positionCurrentLetterThird;
    public bool isGetListLetter = true;
    // Start is called before the first frame update
    public override void Start()
    {
        laneObjects = getLane.laneObjects;
        positionCarStart = getPositionStart.carPositionsStart;
        carPlayer = getObjectCar.carObjects[2];
    }

    // Update is called once per frame
    void Update()
    {
        GetListLetter();
        startPositionLetter = setRandomPositionPhonic.startPositionLetter;
        positionCurrentLetter = listLetter[0].transform.position;
        positionCurrentLetterSecond = listLetter[1].transform.position;
        positionCurrentLetterThird = listLetter[2].transform.position;

        if (GameManager.Instance.IsClickEabled()== true && GameManager.Instance.IsStartGame()==true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine( HandleMouseClick());
            }
        }
    }
    public IEnumerator HandleMouseClick()
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

                if (GameManager.Instance.IsClickLanInstruction() == true)
                {
                    if (objectIndex == 0 )
                    {
                        yield return StartCoroutine(MoveSmoothly(carPlayer, positionCarStart[0], 0.25f));
                        if (carPlayer.transform.position.y == positionCarStart[0].y && positionCurrentLetter.y == startPositionLetter[0].y)
                        {
                            HandSituationTrue();
                        }
                        if (GameManager.Instance.IsPhonicSecond() == true)
                        {
                            if (carPlayer.transform.position.y == positionCarStart[0].y && positionCurrentLetterSecond.y == startPositionLetter[0].y)
                            {
                                HandSituationTrue();
                            }
                        }
                        if (GameManager.Instance.IsPhonicThird() == true)
                        {
                            if (carPlayer.transform.position.y == positionCarStart[0].y && positionCurrentLetterThird.y == startPositionLetter[0].y)
                            {
                                HandSituationTrue();
                            }
                        }
                    }
                    else if (objectIndex == 2)
                    {
                        yield return StartCoroutine(MoveSmoothly(carPlayer, positionCarStart[2], 0.25f));
                        if (carPlayer.transform.position.y == positionCarStart[2].y && positionCurrentLetter.y == startPositionLetter[2].y)
                        {
                       
                            HandSituationTrue();
                        }
                        if (GameManager.Instance.IsPhonicSecond() == true)
                        {
                            if (carPlayer.transform.position.y == positionCarStart[2].y && positionCurrentLetterSecond.y == startPositionLetter[2].y)
                            {
                                HandSituationTrue();
                            }
                        }
                        if (GameManager.Instance.IsPhonicThird() == true)
                        {
                            if (carPlayer.transform.position.y == positionCarStart[2].y && positionCurrentLetterThird.y == startPositionLetter[2].y)
                            {
                                HandSituationTrue();
                            }
                        }
                    }
                    else if (objectIndex == 1 )
                    {
                        yield return StartCoroutine(MoveSmoothly(carPlayer, positionCarStart[1], 0.25f));
                        if (carPlayer.transform.position.y == positionCarStart[1].y && positionCurrentLetter.y == startPositionLetter[1].y)
                        {
                            HandSituationTrue();
                        }
                        if (GameManager.Instance.IsPhonicSecond() == true)
                        {
                            if (carPlayer.transform.position.y == positionCarStart[1].y && positionCurrentLetterSecond.y == startPositionLetter[1].y)
                            {
                                HandSituationTrue();
                            }
                        }
                        if (GameManager.Instance.IsPhonicThird() == true)
                        {
                            if (carPlayer.transform.position.y == positionCarStart[1].y && positionCurrentLetterThird.y == startPositionLetter[1].y)
                            {
                                HandSituationTrue();
                            }
                        }
                    }
                }
                else
                {
                    if (objectIndex == 0 )
                    {
                        StartCoroutine(MoveSmoothly(carPlayer, positionCarStart[0], 0.25f));
                    }
                    else if (objectIndex == 2)
                    {
                        StartCoroutine(MoveSmoothly(carPlayer, positionCarStart[2], 0.25f));
                    }
                    else if (objectIndex == 1)
                    {
                        StartCoroutine(MoveSmoothly(carPlayer, positionCarStart[1], 0.25f));
                    }
                }
            }           
        }
    }
    public void GetListLetter()
    {
        if (GameManager.Instance.IsShowText() && isGetListLetter == true)
        {
            StartCoroutine(getListLetter());
            isGetListLetter = false;
        }
    }

    public IEnumerator getListLetter()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.SetShowText(false);
        listLetter = getLetter.listLetter;
    }
    public void HandSituationTrue()
    {
        GameManager.Instance.SetSoundGuilding(true);
        GameManager.Instance.SetSoundTapHere(false);
        GameManager.Instance.SetHandEnabled(true);
        GameManager.Instance.SetClickLanInstruction(false);
        GameManager.Instance.SetMoveLetterContinous(true);
        GameManager.Instance.SetShowText(false);
    }
}




