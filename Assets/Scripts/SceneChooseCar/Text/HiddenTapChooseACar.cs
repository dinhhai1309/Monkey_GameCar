using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenTapChooseACar : MonoBehaviour
{
    [SerializeField] public GameObject tapChooseACar;
    private void Update()
    {
        if(GameManager.Instance.IsHiddenTextTap() == true)
        {
            HiddenText();
        }
    }

    protected void HiddenText()
    {
        tapChooseACar.SetActive(false);
        GameManager.Instance.SetHiddenTextTap(false);
    }
}
