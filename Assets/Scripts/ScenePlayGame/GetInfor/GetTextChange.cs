using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetTextChange : MonoBehaviour
{
    public List<TextMeshProUGUI> listTextChange; // Sử dụng TextMeshProUGUI thay vì GameObject

    private void Update()
    {
        if (GameManager.Instance.IsShowText() == true)
        {
            StartCoroutine(getListTextChange());
        }
    }

    public IEnumerator getListTextChange()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.SetShowText(false);
        GameObject[] textObjects = GameObject.FindGameObjectsWithTag("textChange");
        foreach (GameObject textObject in textObjects)
        {
            TextMeshProUGUI textMeshPro = textObject.GetComponent<TextMeshProUGUI>();

            // Kiểm tra xem đối tượng có thành phần TextMeshPro không trước khi thêm vào danh sách
            if (textMeshPro != null)
            {
                listTextChange.Add(textMeshPro);
            }
        }
    }
}
