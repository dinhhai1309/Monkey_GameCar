using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class ChangeAnimationCountDown : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject countDown;
    public void Start()
    {
        StartCoroutine(PerformAction());
    }
    public IEnumerator PerformAction()
    {
        yield return new WaitForSeconds(6f);
        countDown.SetActive(true);
        GameManager.Instance.SetSoundCountDown(true);
    }
}
