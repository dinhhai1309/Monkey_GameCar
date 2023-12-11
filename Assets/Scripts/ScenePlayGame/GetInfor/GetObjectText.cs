using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetObjectText : MonoBehaviour
{
    public List<GameObject> objectText;
    // Start is called before the first frame update
    private void Awake()
    {
        getObjectText();
    }
    void Start()
    {
        HideAllTextObjects();
    }

    public void getObjectText()
    {
        objectText = new List<GameObject>(GameObject.FindGameObjectsWithTag("Text"));
    }

    void HideAllTextObjects()
    {
        // Lặp qua danh sách và ẩn từng phần tử
        foreach (GameObject textObject in objectText)
        {
            // nhớ chỉnh lại
            textObject.SetActive(false);
        }
    }
}
