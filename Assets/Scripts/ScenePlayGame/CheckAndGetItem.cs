using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAndGetItem : MonoBehaviour
{
    public GetObjectText getObjectText;
    public List<GameObject> objectText;

    void Start()
    {
        objectText = getObjectText.objectText;
    }

    public void Update()
    {
        if (GameManager.Instance.IsShowText()== true) {
            foreach (GameObject textObject in objectText)
            {
                CheckItem(textObject.name, textObject);
            }
        }
        
    }

    public void CheckItem(string objectName, GameObject showObject)
    {
        // Lấy tên của đối tượng đã click
         string clickedItemName = GameManager.Instance.GetClickedItem();
        // So sánh với tên được truyền vào
        if (clickedItemName == objectName)
        {
            showObject.SetActive(true);
        }
    }
}

