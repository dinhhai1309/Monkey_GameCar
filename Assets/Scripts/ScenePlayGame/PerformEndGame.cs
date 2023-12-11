using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformEndGame : MoveBySpeed
{
    public GameObject despawnBackground;
    public GameObject endGameObject;
    float distanceToMove;
    public GameObject twoFlagObject;
    public GetLetter getLetter;
    public List<GameObject> listLetter;
    public bool isGetLetter = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.IsEndGame() == true){
            SetActiveDespawn();
            StartCoroutine( MoveTwoFlag());
            listLetter[2].SetActive(false);
            MoveBackgroundEnd();// di chuyeern backgroud end game
            GameManager.Instance.SetEndGame(false);
        }
        if (GameManager.Instance.IsShowText() && isGetLetter == true)
        {
            StartCoroutine(getListLetter());
            isGetLetter = false;
        }
    }
    public IEnumerator getListLetter()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.SetShowText(false);
        listLetter = getLetter.listLetter;     
    }
    public void SetActiveDespawn()
    {
        despawnBackground.SetActive(false);
    }

    public void MoveBackgroundEnd()
    {
        distanceToMove = -38f;
        StartCoroutine(MoveToTarget(endGameObject, distanceToMove, 12f));
    }

    public IEnumerator MoveTwoFlag()
    {
        yield return new WaitForSeconds(5f);
        GameManager.Instance.SetSoundAudiecneCheere(true);
        GameManager.Instance.SetMoveFlag(true);
        yield return new WaitForSeconds(2f);
        GameManager.Instance.SetMoveTextEndGame(true);
    }
}
