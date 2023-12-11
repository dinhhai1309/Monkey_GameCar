using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GetItem : MonoBehaviour
{
    protected void OnMouseDown()
    {
        GameManager.Instance.SetClickedItem(this.gameObject.name);
        StartCoroutine(LoadScenePlayGame());
    }

    public IEnumerator LoadScenePlayGame()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("ScenePlayGame");
    }
}
