using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundColliderText : MonoBehaviour
{
    public GetSoundText getSoundText;
    public List<AudioSource> listSoundColliderText;
    public AudioSource soundCollectItem;
    public bool isPlaySound = true;
    public bool isChangeSoundEnd = true;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsSoundColliderText()== true && GameManager.Instance.IsSoundTextAndItem()==true)
        {
            functionGetSoundText();
            if(listSoundColliderText.Count > 0)
            {
                GameManager.Instance.SetSoundTextAndItem(false);
                GameManager.Instance.SetSoundColliderText(false);// bật âm thanh chữ va chạm
                soundCollectItem.Play();
                if (GameManager.Instance.IsPhonicSecond() == true)
                {
                    StartCoroutine(playSoundFirstLetter(listSoundColliderText[1]));
                }
                else if (GameManager.Instance.IsPhonicThird() == true)
                {
                    StartCoroutine(playSoundFirstLetter(listSoundColliderText[2]));
                }
                else 
                {
                    StartCoroutine(playSoundFirstLetter(listSoundColliderText[0]));
                }
            }
        }
        PerformSoundTextEnd();
    }

    public void PerformSoundTextEnd()
    {
        if(GameManager.Instance.IsChangeColorAndSound()==true && isChangeSoundEnd)
        {
            isChangeSoundEnd = false;
            StartCoroutine(PerformPlaySound());
        }
    }

    public IEnumerator PerformPlaySound()
    {
        yield return new WaitForSeconds(1f);
        listSoundColliderText[0].Play();
        yield return new WaitForSeconds(1f);
        listSoundColliderText[1].Play();
        yield return new WaitForSeconds(1f);
        listSoundColliderText[2].Play();
        yield return new WaitForSeconds(1f);
        listSoundColliderText[3].Play();
    }
    public void functionGetSoundText()
    {
        listSoundColliderText = getSoundText.listSoundText;
        // Kiểm tra xem có đối tượng để di chuyển không
        if (listSoundColliderText.Count == 0 || listSoundColliderText[0] == null)
        {
            Debug.LogError("Vui lòng đặt đối tượng cần di chuyển vào trường Object To Move.");
        }
    }

    public IEnumerator playSoundFirstLetter(AudioSource soundLetter)
    {
        yield return new WaitForSeconds(1f);
        soundLetter.Play();
    }
}
