using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SetRandomPositionPhonic : MonoBehaviour
{
    public GetLetter getLetter;
    public List<GameObject> listLetter;
    public List<Vector3> positionLetter;
    public List<Vector3> startPositionLetter;

    protected Vector3 LetterFirst;
    protected Vector3 LetterSecond;
    protected Vector3 LetterThird;
    protected bool isNotColliderLetter= true;
    protected bool isGetListstartPosition = true;
    protected bool isRandomLetter = true;
    protected bool isGetLetter = true;
    private void Update()
    {
        if (GameManager.Instance.IsShowText() && isGetLetter ==true)
        {
            StartCoroutine(PrepareData());
        }

        // Xử lý khi carPlayer không va chạm với collider letter, đặt lại vị trí cho letter để di chuyển lại
        CheckNotColliderLetter();
        if(GameManager.Instance.IsPhonicSecond() == true)
        {
            CheckNotColliderLetterSecond();
        }
        if (GameManager.Instance.IsPhonicThird() == true)
        {
            CheckNotColliderLetterThird();
        }

    }

    public IEnumerator PrepareData()
    {
        yield return new WaitForSeconds(1f);
        isGetLetter = false;
        listLetter = getLetter.listLetter;
        if (isGetListstartPosition == true)
        {
            foreach (GameObject letterObject in listLetter)
            {
                startPositionLetter.Add(letterObject.transform.position);
            }
            isGetListstartPosition = false;
        }
        
        CreatePositionLetter();
        if (isRandomLetter == true)
        {
            RandomLetter();
            isRandomLetter = false;
        }
    }

    public void RandomLetter()
    {

        // Lấy ra 3 vị trí ngẫu nhiên từ positionLetter mà không trùng lặp
        List<Vector3> randomPositions = GetUniqueRandomPositions(3);

        // Đặt 3 gameObject vào các vị trí đã lấy
        for (int i = 0; i < 3; i++)
        {
            if (i < listLetter.Count)
            {
                listLetter[i].transform.position = randomPositions[i];
            }
            else
            {
                Debug.LogError("Index out of range in listLetter.");
            }
        }
    }

    private List<Vector3> GetUniqueRandomPositions(int count)
    {
        List<Vector3> uniquePositions = new List<Vector3>();
        List<int> selectedIndices = new List<int>();

        for (int i = 0; i < count; i++)
        {
            int randomIndex;

            // Đảm bảo rằng randomIndex không trùng lặp
            do
            {
                randomIndex = Random.Range(0, positionLetter.Count);
            } while (selectedIndices.Contains(randomIndex));

            selectedIndices.Add(randomIndex);
            uniquePositions.Add(positionLetter[randomIndex]);
        }

        return uniquePositions;
    }

    // lưu vị trí của letter sau khi random
    public void CreatePositionLetter()
    {
        positionLetter.Clear();

        foreach (GameObject letterObject in listLetter)
        {
            positionLetter.Add(letterObject.transform.position);
        }
    }

    public void CheckNotColliderLetter()
    {
        if (GameManager.Instance.IsCheckNotColliderLetter() == true && GameManager.Instance.IsCheckResetLetter()==true)
        {
            listLetter[0].transform.position = positionLetter[0];
            GameManager.Instance.SetCheckResetLetter(false);
        }
    }
    public void CheckNotColliderLetterSecond()
    {
        if (GameManager.Instance.IsCheckNotColliderLetter() == true && GameManager.Instance.IsResetPhonicSecond() == true)
        {
            listLetter[1].transform.position = positionLetter[1];
            GameManager.Instance.SetResetPhonicSecond(false);
        }
    }

    public void CheckNotColliderLetterThird()
    {

        if (GameManager.Instance.IsCheckNotColliderLetter() == true && GameManager.Instance.IsResetPhonicThird() == true)
        {
            listLetter[2].transform.position = positionLetter[2];
            GameManager.Instance.SetResetPhonicThird(false);
        }
    }
}
