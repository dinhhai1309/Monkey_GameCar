using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private bool isPlaySoundText = false;
    private bool isPlaySoundPodium = false;
    private bool isScaleText = false;
    private bool isClickEabled = false;
    private bool isPlaySoundChooseSuccess = false; //
    private bool isHiddenTextTap = false;
    private bool isLoadScence = false;
    private bool isSoundCountDown = false;
    private string clickedObjectName; // Changed variable to store the clicked object's name

    public void Update()
    {
    }
    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Đảm bảo rằng đối tượng GameManager không bị hủy khi chuyển scene
        }
        else
        {
            Destroy(gameObject); // Nếu đã tồn tại một đối tượng GameManager khác, hủy bản thân đối tượng này
        }
    }

    // moveCarAndPodium sử dụng
    public bool IsPlaySoundText()
    {
        return isPlaySoundText;
    }

    public void SetPlaySoundText(bool value)
    {
        isPlaySoundText = value;
    }

    public bool IsPlaySoundPodium()
    {
        return isPlaySoundPodium;
    }

    public void SetPlaySoundPodium(bool value)
    {
        isPlaySoundPodium = value;
    }

    public bool IsScaleText()
    {
        return isScaleText;
    }

    public void SetScaleText(bool value)
    {
        isScaleText = value;
    }

    public bool IsClickEabled()
    {
        return isClickEabled;
    }

    public void SetClickEabled(bool value)
    {
        isClickEabled = value;
    }

    public bool IsPlaySoundChooseSuccess()
    {
        return isPlaySoundChooseSuccess;
    }

    public void SetPlaySoundChooseSuccess(bool value)
    {
        isPlaySoundChooseSuccess = value;
    }

    public bool IsHiddenTextTap()
    {
        return isHiddenTextTap;
    }

    public void SetHiddenTextTap(bool value)
    {
        isHiddenTextTap = value;
    }

    public bool IsLoadScence()
    {
        return isLoadScence;
    }

    public void SetLoadScence(bool value)
    {
        isLoadScence = value;
    }

    public bool IsSoundCountDown()
    {
        return isSoundCountDown;
    }

    public void SetSoundCountDown(bool value)
    {
        isSoundCountDown = value;
    }

    public string GetClickedObjectName()
    {
        return clickedObjectName;
    }

    public void SetClickedObjectName(string objName)
    {
        clickedObjectName = objName;
    }
}
