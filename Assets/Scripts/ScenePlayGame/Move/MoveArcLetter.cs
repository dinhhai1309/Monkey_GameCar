using System.Collections;
using UnityEngine;
using System.Collections.Generic;
public class MoveArcLetter : MoveByTime
{
    public GetLetter getLetter;
    public MoveEachLetter moveEachLetter;
    public List<GameObject> ListLetter;
    public Vector3 targetPosition;
    public bool isGetLetter = true;
    public override void Start()
    {
        targetPosition = new Vector3(-1.5f, -4.5f, 0);
    }

    void Update()
    {
        if (GameManager.Instance.IsMoveArcLetter()== true)
        {
            if(isGetLetter == true)
            {
                functionGetLetter();
                isGetLetter = false;
            }

            if (ListLetter.Count > 0 && ListLetter[0] != null)
            {
                moveEachLetter.setActiveMoveToTarget();
                StartCoroutine(MoveSmoothly(ListLetter[0], targetPosition, 1f));
                if (GameManager.Instance.IsPhonicSecond() == true && GameManager.Instance.IsColliderPhonicSecond() == true) // CheckColliderLetter
                {
                    StartCoroutine(MoveSmoothly(ListLetter[1], targetPosition, 1f));
                    GameManager.Instance.SetColliderPhonicSecond(false);
                }
                if (GameManager.Instance.IsPhonicThird() == true && GameManager.Instance.IsColliderPhonicThird() == true) // CheckColliderLetter
                {
                    StartCoroutine(MoveSmoothly(ListLetter[2], targetPosition, 1f));
                    GameManager.Instance.SetColliderPhonicThird(false);
                }
                StartCoroutine(isChangeColor());
                GameManager.Instance.SetMoveArcLetter(false); // class MoveEachLetter
            }
        }
    }

    public void functionGetLetter()
    {
        ListLetter = getLetter.listLetter;
        // Kiểm tra xem có đối tượng để di chuyển không
        if (ListLetter.Count == 0 || ListLetter[0] == null)
        {
            Debug.LogError("Vui lòng đặt đối tượng cần di chuyển vào trường Object To Move.");
        }
    }

    public IEnumerator isChangeColor()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.SetChangeColorText(true);
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.SetMoveCarPlayer(true); // di chuyển chữ khi va chạm
        GameManager.Instance.SetMoveCarPlayerSecond(true);

    }
}
