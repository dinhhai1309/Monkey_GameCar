using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEachLetter : MoveBySpeed
{
    public GetLetter getLetter;
    public SetRandomPositionPhonic setRandomPositionPhonic;
    public MoveHand moveHand;
    public List<GameObject> ListLetter;
    public List<Vector3> positionLetter;
    public float speedLetter;
    protected float distanceToMove;
    protected Vector3 positionIntroOneLetter;
    protected bool isGetPositionLetter = true;
    protected bool isMoveLetter = true;
    protected bool isMoveLetterFirst = true;
    protected bool isGetLetter = true;
    protected bool isGetListPositionLetter = true;

    // Start is called before the first frame update
    void Start()
    {
        speedLetter = 4f;
        distanceToMove = -25f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsShowText() && isGetLetter == true)
        {
            StartCoroutine( getListLetter());
            isGetLetter = false;
        }
        if (GameManager.Instance.IsPhonicFirst() == true && isMoveLetterFirst == true)
        {
            // thực hiện chữ đầu tiên 
            PerformPhonicFirst(ListLetter[0]);
            isMoveLetterFirst = false;
        }
        if (GameManager.Instance.IsPhonicSecond() == true && GameManager.Instance.IsMoveLetterSecond() == true)
        {
            // thực hiện chữ thứ hai 
            GameManager.Instance.SetCompleteInstruction(true);
            GameManager.Instance.SetMoveLetterSecond(false);// dừng việc check đến chữ thứ 2
            StartCoroutine(SetCheckMoveLetterSecondd());
            GameManager.Instance.SetStartMoveLetter(true);
            ListLetter[0].SetActive(false);
            PerformPhonicFirst(ListLetter[1]);          
        }
        if (GameManager.Instance.IsPhonicThird() == true && GameManager.Instance.IsMoveLetterThird() == true)
        {
            // thực hiện chữ thứ ba 
            GameManager.Instance.SetCompleteInstruction(true);
            GameManager.Instance.SetMoveLetterThird(false);// dừng việc check đến chữ thứ 2
            StartCoroutine(SetCheckMoveLetterSecondd());
            GameManager.Instance.SetStartMoveLetter(true);
            ListLetter[1].SetActive(false);
            PerformPhonicFirst(ListLetter[2]);
        }
        CheckNotCollider();
        CheckNotColliderThird();
        CheckCompleteInstruction();
    }

    public IEnumerator SetCheckMoveLetterSecondd()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.SetAllowCheckColliderLetter(true);

    }
    public void PerformPhonicFirst(GameObject objectLetter)
    {
        if (GameManager.Instance.IsCompleteInstruction() == true)
        {
            StartCoroutine(delaySecond(objectLetter));
            GameManager.Instance.SetCompleteInstruction(false);
        }
    }
    public IEnumerator delaySecond(GameObject objectLetter)
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(MoveToTarget(objectLetter, distanceToMove, speedLetter));
        GameManager.Instance.SetStartMoveLetter(true); // class CheckColliderLetter
    }

    public IEnumerator getListLetter()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.SetShowText(false);
        ListLetter = getLetter.listLetter;
        GetPositionLetter();
    }

    public void setActiveMoveToTarget()
    {
        gameObject.SetActive(false);
    }

    // hàm di chuyển lại khi không chạm vào chữ
    public void CheckNotCollider()
    {
        if (GameManager.Instance.IsCheckNotColliderLetter() == true) // checkColliderletter
        {
            MoveReplayLetter(ListLetter[0]);
            if (GameManager.Instance.IsPhonicSecond() == true)
            {
                MoveReplayLetter(ListLetter[1]);
            }
            if (GameManager.Instance.IsPhonicThird() == true)
            {
                MoveReplayLetter(ListLetter[2]);
            }
        }
    }
    public void MoveReplayLetter(GameObject letterObject)
    {
        StartCoroutine(MoveToTarget(letterObject, distanceToMove, speedLetter));
        GameManager.Instance.SetCheckNotColliderLetter(false);// dừng lại chức năng CheckNotcCollider()
        GameManager.Instance.SetAllowCheckColliderLetter(true);// CheckcolliderLetter, cho phép đếm giây để kiểm tra va chạm
        GameManager.Instance.SetCheckResetLetter(true);
    }
    public void GetPositionLetter()
    {
        positionLetter = setRandomPositionPhonic.positionLetter;
        isGetListPositionLetter = false;
    }
    public void CheckNotColliderThird()
    {
        if (GameManager.Instance.IsNotColliderLetterThird() == true)
        {
            //isMoveLetter = false;
            GameManager.Instance.SetNotColliderLetterThird(false);
            PerformNotCollider(ListLetter[0],0);
            if (GameManager.Instance.IsPhonicSecond() == true)
            {
                PerformNotCollider(ListLetter[1],1);
            }
            if (GameManager.Instance.IsPhonicThird() == true)
            {
                PerformNotCollider(ListLetter[2], 2);
            }
            GameManager.Instance.SetClickLanInstruction(true);
        }
    }
    public void PerformNotCollider(GameObject letterObject, int indexLetter)
    {
        letterObject.transform.position = positionLetter[indexLetter];
        StartCoroutine(MoveToTarget(letterObject, -5.4f, speedLetter));
        moveHand.MoveHandInstruction(letterObject.transform.position);
    }
    public void CheckCompleteInstruction()
    {
        if(GameManager.Instance.IsMoveLetterContinous() == true)
        {
            GameManager.Instance.SetStartMoveLetter(true);
            GameManager.Instance.SetAllowCheckColliderLetter(true);
            StartCoroutine(MoveToTarget(ListLetter[0], -15f, speedLetter));
            if (GameManager.Instance.IsPhonicSecond() == true)
            {
                StartCoroutine(MoveToTarget(ListLetter[1], -15f, speedLetter));
            }
            if (GameManager.Instance.IsPhonicThird() == true)
            {
                StartCoroutine(MoveToTarget(ListLetter[2], -15f, speedLetter));
            }
            GameManager.Instance.SetMoveLetterContinous(false);
        }
    }
}
