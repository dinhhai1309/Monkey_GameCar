using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextScaling : ScaleByTime
{
    public GameManager gameManager;
    [SerializeField]public GameObject tapToChooseACar;
    private void Update()
    {
        if(GameManager.Instance.IsScaleText() == true)
        {
            ScaleText();
            GameManager.Instance.SetScaleText(false);
        }
    }
    public void ScaleText()
    {
        startScale = new Vector3(0f, 1f, 1f);
        targetScale = new Vector3(1.1f, 1.0f, 1.0f);
        StartCoroutine(ScaleObjectCar(tapToChooseACar,startScale, targetScale, 1f));
        StartCoroutine(DelayOneSecond());
    }
    public IEnumerator DelayOneSecond()
    {
        yield return new WaitForSeconds(1f);
        ScaleTextOne();
    }
    public void ScaleTextOne()
    {
        targetScale = new Vector3(1.1f, 1.0f, 1.0f);
        StartCoroutine(ScaleObjectCar(tapToChooseACar,targetScale, Vector3.one, 0.5f)); // Thu nhỏ về kích thước ban đầu (1.0)
        GameManager.Instance.SetClickEabled(true);
    }


}
