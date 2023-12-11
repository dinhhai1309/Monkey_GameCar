using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLetter : MonoBehaviour
{
    public List<GameObject> listLetter;

    private void Update()
    {
        if(GameManager.Instance.IsShowText() == true)
        {
            StartCoroutine(getListLetter());
        }
    }
    public IEnumerator getListLetter()
    {
        yield return new WaitForSeconds(0.5f);
        listLetter = new List<GameObject>(GameObject.FindGameObjectsWithTag("LetterPlay"));
    }
}
