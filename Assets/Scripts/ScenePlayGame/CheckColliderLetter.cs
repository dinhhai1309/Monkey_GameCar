using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColliderLetter : MonoBehaviour
{
    private bool hasCollided = false;
    private bool hasSoundHappy = false;
    private bool hasSoundDis = true;
    private bool coutCollider = true;
    private bool coutColliderThird = true;
    private bool coutColliderFour = true;
    private bool isCheckMoveSecondCar = true;

    private int collisionCount = 0; // Biến để đếm số lần có va chạm
    private float elapsedTime = 0f;
    private int noCollisionCount = 0; // Biến để đếm số lần không có va chạm
    public int maxNoCollisionCount = 2; // Số lần không có va chạm tối đa trước khi thực hiện chức năng B
    public GameObject moveEachLetter;
    public GetPositionStart getPositionStart;
    public List<Vector3> listPositionCar;

    private void Start()
    {
        listPositionCar = getPositionStart.carPositionsStart;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LetterPlay"))
        {
            hasCollided = true; // Gán giá trị true khi có va chạm với "LetterPlay"
            hasSoundHappy = true;
            collisionCount++; // Tăng biến đếm khi có va chạm
        }

        if (collision.CompareTag("Power"))
        {
            GameManager.Instance.SetCheckColliderPower(true);
        }
    }

    public void Update()
    {
        if (GameManager.Instance.IsStartMoveLetter() == true && GameManager.Instance.IsAllowCheckColliderLetter() == true)
        {
            elapsedTime += Time.deltaTime;
            //Debug.Log(elapsedTime);
            if (elapsedTime >= 8f)
            {
                if (hasCollided == false)
                {
                    noCollisionCount++;
                    GameManager.Instance.SetCheckNotColliderLetter(true);//setRandomPositinPhonic, reset lại vị trí
                    GameManager.Instance.SetCheckNotColliderLetterSecond(true);//MoveEachLetter, reset lại vị trí
                    GameManager.Instance.SetCheckResetLetter(true);
                    GameManager.Instance.SetResetPhonicSecond(true);
                    GameManager.Instance.SetResetPhonicThird(true);
                    hasSoundDis = true;
                    if (noCollisionCount == maxNoCollisionCount)
                    {
                        // xử lý 2laafn không chạm chữ
                        GameManager.Instance.SetNotColliderLetterThird(true); // moveEachLetter, xử lý khi 2 lần không chạm
                        GameManager.Instance.SetCompleteInstruction(false); // class moveEachLetter, không di chuyển letter nữa
                        GameManager.Instance.SetCheckNotColliderLetter(false); // moveEachLetter, không di chuyển lại ưnax
                        noCollisionCount = 0;
                    }
                }

                GameManager.Instance.SetAllowCheckColliderLetter(false);
                hasSoundDis = true;
                elapsedTime = 0f;
            }
            if (elapsedTime >= 6f && elapsedTime <6.01f)
            {
                if (hasCollided == false && hasSoundDis == true)
                {
                    hasSoundDis = false;
                    // thực hiện khán giả buồn và xe khác lùi lại nếu có
                    GameManager.Instance.SetMoveAudience(true);
                    GameManager.Instance.SetCheckMoveAudience(true);
                    GameManager.Instance.SetChangeAudienceDisapointed(true);
                    GameManager.Instance.SetSoundAudienceDisapointed(true);
                    GameManager.Instance.SetMoveCarOneDis(true);
                    if (hasCollided == false && collisionCount == 2)
                    {
                        GameManager.Instance.SetMoveCarSecondDis(true);
                    }
                }
            }
            if (hasCollided && hasSoundHappy)
            {
                GameManager.Instance.SetColliderLetter(true); // class CollisionHanding
                GameManager.Instance.SetMoveCarOnehappy(true);
                noCollisionCount = 0; // Đặt lại biến đếm khi có va chạm
                hasSoundHappy = false;
            }
            if (GameManager.Instance.IsPhonicSecond() == true && hasCollided==true)
            {
                GameManager.Instance.SetColliderPhonicSecond(true); // class MoveArcLetter
            }
            if (GameManager.Instance.IsPhonicThird() == true && hasCollided == true)
            {
                GameManager.Instance.SetColliderPhonicThird(true); // class MoveArcLetter
            }
        }
        else
        {
            // Nếu không thỏa mãn điều kiện, reset giá trị
            hasCollided = false;
            elapsedTime = 0f;
        }

        StartCoroutine(CheckColliderCount());
        
    }

    public IEnumerator CheckColliderCount()
    {
        if(collisionCount == 1 && coutCollider ==true)
        {
            yield return new WaitForSeconds(5f);
            moveEachLetter.SetActive(true);
            GameManager.Instance.SetPhonicSecond(true);
            coutCollider = false;
        }
         if (collisionCount == 2 && coutColliderThird == true)
        {
            CheckMoveOverTakecar();
            yield return new WaitForSeconds(5f);
            moveEachLetter.SetActive(true);
            GameManager.Instance.SetPhonicSecond(false);
            GameManager.Instance.SetPhonicThird(true);
            coutColliderThird = false;
        }
        if (collisionCount == 3 && coutColliderFour == true)
        {
            CheckMoveOverTakecar();
            yield return new WaitForSeconds(5f);
            moveEachLetter.SetActive(true);
            GameManager.Instance.SetCheckCompletePhonic(true);// xử lý khi đã chạm cả 3 chữ, MovePower
            coutColliderFour = false;
        }
    }


    public void CheckMoveOverTakecar()
    {
        if (listPositionCar[0].x> -5.5f && listPositionCar[1].x < -5.5f && isCheckMoveSecondCar==true&& collisionCount == 2)
        {
            // Di chuyển xe thứ 2
            GameManager.Instance.SetMoveCarSecond(true);
            isCheckMoveSecondCar = false;
        }
    }
}
