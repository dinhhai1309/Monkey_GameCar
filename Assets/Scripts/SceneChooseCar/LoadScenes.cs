using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.IsLoadScence() == true)
        {
            StartCoroutine(ChangeScene());
        }
    }

    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("SceneChooseText");
    }
}
