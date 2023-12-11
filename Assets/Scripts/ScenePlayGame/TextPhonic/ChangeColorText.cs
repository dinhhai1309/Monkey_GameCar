using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeColorText : MonoBehaviour
{
    public GetTextChange getTextChange;
    public List<TextMeshProUGUI> objectTextChange;
    public bool ChangeColorEndGame = true;
    // Start is called before the first frame updat

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsChangeColorText())
        {
            functionGetLetter();
            if(objectTextChange.Count > 0)
            {
                if (GameManager.Instance.IsPhonicSecond() == true)
                {
                    ChangeColor(objectTextChange[1]);

                }
                if(GameManager.Instance.IsPhonicThird() == true)
                {
                    ChangeColor(objectTextChange[2]);
                }
                else
                {
                    ChangeColor(objectTextChange[0]);
                }

            }
            GameManager.Instance.SetChangeColorText(false);
        }
        if (GameManager.Instance.IsChangeColorAndSound() == true && ChangeColorEndGame)
        {
            ChangeColorEndGame = false;
            StartCoroutine( PerformChangeColor());
        }
    }

    public void functionGetLetter()
    {
        objectTextChange = getTextChange.listTextChange;
        // Kiểm tra xem có đối tượng để di chuyển không
        if (objectTextChange.Count == 0 || objectTextChange[0] == null)
        {
            Debug.LogError("Vui lòng đặt đối tượng cần di chuyển vào trường Object To Move.");
        }
    }

    public void ChangeColor(TextMeshProUGUI letterChange){
        letterChange.color = Color.white;
    }
    public IEnumerator PerformChangeColor()
    {
        yield return new WaitForSeconds(1f);
        ChangeColorOrange(objectTextChange[0]);
        yield return new WaitForSeconds(1f);
        ChangeColor(objectTextChange[0]);
        ChangeColorOrange(objectTextChange[1]);
        yield return new WaitForSeconds(1f);
        ChangeColor(objectTextChange[1]);
        ChangeColorOrange(objectTextChange[2]);
        yield return new WaitForSeconds(1f);
        ChangeColorOrange(objectTextChange[0]);
        ChangeColorOrange(objectTextChange[1]);
        ChangeColorOrange(objectTextChange[2]);

    }

    public void ChangeColorOrange(TextMeshProUGUI letterChange)
    {
        letterChange.color = Color.red;
    }
}
