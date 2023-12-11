using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSoundText : MonoBehaviour
{
    public List<AudioSource> listSoundText; // Sử dụng TextMeshProUGUI thay vì GameObject
    public bool isGetList = true;
    private void Update()
    {
        if (GameManager.Instance.IsShowText() == true && isGetList)
        {
            StartCoroutine(getListSoundText());
            isGetList = false;
        }
    }

    public IEnumerator getListSoundText()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject[] textObjects = GameObject.FindGameObjectsWithTag("SoundText");
        foreach (GameObject textObject in textObjects)
        {
            AudioSource soundText = textObject.GetComponent<AudioSource>();

            // Kiểm tra xem đối tượng có thành phần TextMeshPro không trước khi thêm vào danh sách
            if (soundText != null)
            {
                listSoundText.Add(soundText);
            }
        }
    }
}
