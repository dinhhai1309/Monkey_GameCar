using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private bool isPlaySoundText = false;
    private bool isPlaySoundPodium = false;
    private bool isPlaySoundChooseSuccess = false; //
    private bool isSoundTapHere = false;
    private bool isSoundCheere = false;
    private bool isSoundGuilding = false;
    private bool isSoundPlayGame = false;
    private bool isSoundAudienceHappy = false;
    private bool isSoundAudienceHappySecond = false;
    private bool isSoundAudienceDisapointed = false;
    private bool isSoundColliderText = false;
    private bool isSoundAudiecneCheere = false;

    private bool isMoveBackground = false;
    private bool isMoveAudience = false;
    private bool isMoveArcLetter = false;
    private bool isMoveCarPlayer = false;
    private bool isMoveCarPlayerSecond = true;
    private bool isStartMoveLetter = false;
    private bool isMoveLetterContinous = false;
    private bool isMoveLetterSecond = true;
    private bool isMoveLetterThird = true;
    private bool isMoveCarSecond = false;
    private bool isMovePower = false;
    private bool isMoveFlag = false;
    private bool isMoveTwoCarEnd = false;
    private bool isMoveCarColliderPower = true;
    private bool isMoveTextEndGame = false; //
    private bool isMoveCarOneDis = false; //
    private bool isMoveCarOnehappy = false; //
    private bool isMoveCarSecondDis = false; //


    private bool isChangeAnimationSpeedUp = false;
    private bool isChangeAnimationLoop = false;
    private bool isChangeAnimationCarPlayer = true;
    private bool isChangeAnimationPlusSpeed = false;
    private bool isChangeAnimationCarReverses = false;
    private bool isChangeAnimationNomarl = false;
    private bool isChangeAudienceDisapointed = false;
    private bool isChangeAudienceHappy = false;

    private bool isScaleText = false;
    private bool isClickEabled = false;
    private bool isHiddenTextTap = false;
    private bool isLoadScence = false;
    private bool isClickObject = false;
    private bool isChangeLandInstruction = false;
    private bool isStartGame = false;
    private bool isHandEnabled = false;
    private bool isShowText = false;
    private bool isCompleteInstruction = false;
    private bool isColliderLetter = false;
    private bool isAllowCheckColliderLetter = true;
    private bool isCheckResetLetter = true;
    private bool isChangeColorText = false;
    private bool isChangeColorAndSound = false;
    private bool isCheckNotColliderLetter = false;
    private bool isCheckNotColliderLetterSecond = true;
    private bool isSoundTextAndItem = true;

    private bool isNotColliderLetterThird = false;
    private bool isClickLanInstruction = false;
    private bool isPhonicFirst = false;
    private bool isPhonicSecond = false;
    private bool isPhonicThird = false;
    private bool isCheckMoveAudience = true;
    private bool isColliderPhonicSecond = false;
    private bool isColliderPhonicThird = false;
    private bool isChangeColorSecond = false;
    private bool isCheckCompletePhonic = false;
    private bool isCheckColliderPower = false;
    private bool isPlaySoundPlusSpeed = true;
    private bool isEndGame = false;
    private bool isScaleTextAndFrame = false;
    private bool isResetPhonicSecond = false;
    private bool isResetPhonicThird = false;


    private TextMeshProUGUI TextItem;
    private AudioSource soundItem;
    private string clickedObjectName; // Changed variable to store the clicked object's name
    private string clickedItem;
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
    public bool IsMoveCarOnehappy()
    {
        return isMoveCarOnehappy;
    }

    public void SetMoveCarOnehappy(bool value)
    {
        isMoveCarOnehappy = value;
    }

    public bool IsMoveCarOneDis()
    {
        return isMoveCarOneDis;
    }

    public void SetMoveCarOneDis(bool value)
    {
        isMoveCarOneDis = value;
    }
    public bool IsMoveCarSecondDis()
    {
        return isMoveCarSecondDis;
    }

    public void SetMoveCarSecondDis(bool value)
    {
        isMoveCarSecondDis = value;
    }
    public bool IsResetPhonicThird()
    {
        return isResetPhonicThird;
    }

    public void SetResetPhonicThird(bool value)
    {
        isResetPhonicThird = value;
    }
    public bool IsResetPhonicSecond()
    {
        return isResetPhonicSecond;
    }

    public void SetResetPhonicSecond(bool value)
    {
        isResetPhonicSecond = value;
    }
    public bool IsScaleTextAndFrame()
    {
        return isScaleTextAndFrame;
    }

    public void SetScaleTextAndFrame(bool value)
    {
        isScaleTextAndFrame = value;
    }
    public bool IsChangeColorAndSound()
    {
        return isChangeColorAndSound;
    }

    public void SetChangeColorAndSound(bool value)
    {
        isChangeColorAndSound = value;
    }
    public bool IsMoveTextEndGame()
    {
        return isMoveTextEndGame;
    }

    public void SetMoveTextEndGame(bool value)
    {
        isMoveTextEndGame = value;
    }
    public bool IsSoundAudiecneCheere()
    {
        return isSoundAudiecneCheere;
    }

    public void SetSoundAudiecneCheere(bool value)
    {
        isSoundAudiecneCheere = value;
    }

    public bool IsMoveTwoCarEnd()
    {
        return isMoveTwoCarEnd;
    }

    public void SetMoveTwoCarEnd(bool value)
    {
        isMoveTwoCarEnd = value;
    }
    public bool IsMoveFlag()
    {
        return isMoveFlag;
    }

    public void SetMoveFlag(bool value)
    {
        isMoveFlag = value;
    }
    public bool IsEndGame()
    {
        return isEndGame;
    }

    public void SetEndGame(bool value)
    {
        isEndGame = value;
    }
    public bool IsChangeAnimationPlusSpeed()
    {
        return isChangeAnimationPlusSpeed;
    }

    public void SetChangeAnimationPlusSpeed(bool value)
    {
        isChangeAnimationPlusSpeed = value;
    }
    public bool IsMoveCarColliderPower()
    {
        return isMoveCarColliderPower;
    }

    public void SetMoveCarColliderPower(bool value)
    {
        isMoveCarColliderPower = value;
    }

    public bool IsPlaySoundPlusSpeed()
    {
        return isPlaySoundPlusSpeed;
    }

    public void SetPlaySoundPlusSpeed(bool value)
    {
        isPlaySoundPlusSpeed = value;
    }
    public bool IsCheckColliderPower()
    {
        return isCheckColliderPower;
    }

    public void SetCheckColliderPower(bool value)
    {
        isCheckColliderPower = value;
    }
    public bool IsMovePower()
    {
        return isMovePower;
    }

    public void SetMovePower(bool value)
    {
        isMovePower = value;
    }

    public bool IsCheckCompletePhonic()
    {
        return isCheckCompletePhonic;
    }

    public void SetCheckCompletePhonic(bool value)
    {
        isCheckCompletePhonic = value;
    }
    public bool IsMoveCarSecond()
    {
        return isMoveCarSecond;
    }

    public void SetMoveCarSecond(bool value)
    {
        isMoveCarSecond = value;
    }
    public bool IsChangeAnimationCarPlayer()
    {
        return isChangeAnimationCarPlayer;
    }

    public void SetChangeAnimationCarPlayer(bool value)
    {
        isChangeAnimationCarPlayer = value;
    }
    public bool IsMoveCarPlayerSecond()
    {
        return isMoveCarPlayerSecond;
    }

    public void SetMoveCarPlayerSecond(bool value)
    {
        isMoveCarPlayerSecond = value;
    }
    public bool IsColliderPhonicThird()
    {
        return isColliderPhonicThird;
    }

    public void SetColliderPhonicThird(bool value)
    {
        isColliderPhonicThird = value;
    }
    public bool IsMoveLetterThird()
    {
        return isMoveLetterThird;
    }

    public void SetMoveLetterThird(bool value)
    {
        isMoveLetterThird = value;
    }
    public bool IsSoundTextAndItem()
    {
        return isSoundTextAndItem;
    }

    public void SetSoundTextAndItem(bool value)
    {
        isSoundTextAndItem = value;
    }
    public bool IsCheckNotColliderLetterSecond()
    {
        return isCheckNotColliderLetterSecond;
    }

    public void SetCheckNotColliderLetterSecond(bool value)
    {
        isCheckNotColliderLetterSecond = value;
    }
    public bool IsChangeColorSecond()
    {
        return isChangeColorSecond;
    }

    public void SetChangeColorSecond(bool value)
    {
        isChangeColorSecond = value;
    }
    public bool IsColliderPhonicSecond()
    {
        return isColliderPhonicSecond;
    }

    public void SetColliderPhonicSecond(bool value)
    {
        isColliderPhonicSecond = value;
    }
    public bool IsMoveLetterSecond()
    {
        return isMoveLetterSecond;
    }

    public void SetMoveLetterSecond(bool value)
    {
        isMoveLetterSecond = value;
    }
    public bool IsCheckMoveAudience()
    {
        return isCheckMoveAudience;
    }

    public void SetCheckMoveAudience(bool value)
    {
        isCheckMoveAudience = value;
    }
    public bool IsSoundAudienceHappySecond()
    {
        return isSoundAudienceHappySecond;
    }

    public void SetSoundAudienceHappySecond(bool value)
    {
        isSoundAudienceHappySecond = value;
    }
    public bool IsPhonicFirst()
    {
        return isPhonicFirst;
    }

    public void SetPhonicFirst(bool value)
    {
        isPhonicFirst = value;
    }
    public bool IsPhonicSecond()
    {
        return isPhonicSecond;
    }

    public void SetPhonicSecond(bool value)
    {
        isPhonicSecond = value;
    }
    public bool IsPhonicThird()
    {
        return isPhonicThird;
    }

    public void SetPhonicThird(bool value)
    {
        isPhonicThird = value;
    }
    public bool IsSoundAudienceDisapointed()
    {
        return isSoundAudienceDisapointed;
    }

    public void SetSoundAudienceDisapointed(bool value)
    {
        isSoundAudienceDisapointed = value;
    }
    public bool IsChangeAudienceDisapointed()
    {
        return isChangeAudienceDisapointed;
    }

    public void SetChangeAudienceDisapointed(bool value)
    {
        isChangeAudienceDisapointed = value;
    }
    public bool IsChangeAudienceHappy()
    {
        return isChangeAudienceHappy;
    }

    public void SetChangeAudienceHappy(bool value)
    {
        isChangeAudienceHappy = value;
    }
    public bool IsMoveLetterContinous()
    {
        return isMoveLetterContinous;
    }

    public void SetMoveLetterContinous(bool value)
    {
        isMoveLetterContinous = value;
    }
    public bool IsClickLanInstruction()
    {
        return isClickLanInstruction;
    }

    public void SetClickLanInstruction(bool value)
    {
        isClickLanInstruction = value;
    }
    public bool IsNotColliderLetterThird()
    {
        return isNotColliderLetterThird;
    }

    public void SetNotColliderLetterThird(bool value)
    {
        isNotColliderLetterThird = value;
    }
    public bool IsCheckResetLetter()
    {
        return isCheckResetLetter;
    }

    public void SetCheckResetLetter(bool value)
    {
        isCheckResetLetter = value;
    }
    public bool IsAllowCheckColliderLetter()
    {
        return isAllowCheckColliderLetter;
    }

    public void SetAllowCheckColliderLetter(bool value)
    {
        isAllowCheckColliderLetter = value;
    }
    public bool IsCheckNotColliderLetter()
    {
        return isCheckNotColliderLetter;
    }

    public void SetCheckNotColliderLetter(bool value)
    {
        isCheckNotColliderLetter = value;
    }
    public bool IsChangeAnimationLoop()
    {
        return isChangeAnimationLoop;
    }

    public void SetChangeAnimationLoop(bool value)
    {
        isChangeAnimationLoop = value;
    }
    public bool IsChangeAnimationNomarl()
    {
        return isChangeAnimationNomarl;
    }

    public void SetChangeAnimationNomarl(bool value)
    {
        isChangeAnimationNomarl = value;
    }
    public bool IsChangeAnimationCarReverses()
    {
        return isChangeAnimationCarReverses;
    }

    public void SetChangeAnimationCarReverses(bool value)
    {
        isChangeAnimationCarReverses = value;
    }
    public bool IsMoveCarPlayer()
    {
        return isMoveCarPlayer;
    }

    public void SetMoveCarPlayer(bool value)
    {
        isMoveCarPlayer = value;
    }
    public bool IsChangeAnimationSpeedUp()
    {
        return isChangeAnimationSpeedUp;
    }

    public void SetChangeAnimationSpeedUp(bool value)
    {
        isChangeAnimationSpeedUp = value;
    }
    public bool IsSoundAudienceHappy()
    {
        return isSoundAudienceHappy;
    }

    public void SetSoundAudienceHappy(bool value)
    {
        isSoundAudienceHappy = value;
    }
    public bool IsSoundColliderText()
    {
        return isSoundColliderText;
    }

    public void SetSoundColliderText(bool value)
    {
        isSoundColliderText = value;
    }
    public bool IsMoveArcLetter()
    {
        return isMoveArcLetter;
    }

    public void SetMoveArcLetter(bool value)
    {
        isMoveArcLetter = value;
    }
    public bool IsMoveAudience()
    {
        return isMoveAudience;
    }

    public void SetMoveAudience(bool value)
    {
        isMoveAudience = value;
    }
    public bool IsChangeColorText()
    {
        return isChangeColorText;
    }

    public void SetChangeColorText(bool value)
    {
        isChangeColorText = value;
    }
    public bool IsColliderLetter()
    {
        return isColliderLetter;
    }

    public void SetColliderLetter(bool value)
    {
        isColliderLetter = value;
    }
    public bool IsStartMoveLetter()
    {
        return isStartMoveLetter;
    }

    public void SetStartMoveLetter(bool value)
    {
        isStartMoveLetter = value;
    }
    public bool IsCompleteInstruction()
    {
        return isCompleteInstruction;
    }

    public void SetCompleteInstruction(bool value)
    {
        isCompleteInstruction = value;
    }
    public bool IsSoundPlayGame()
    {
        return isSoundPlayGame;
    }

    public void SetSoundPlayGame(bool value)
    {
        isSoundPlayGame = value;
    }
    public bool IsSoundCheere()
    {
        return isSoundCheere;
    }

    public void SetSoundCheere(bool value)
    {
        isSoundCheere = value;
    }

    public bool IsShowText()
    {
        return isShowText;
    }

    public void SetShowText(bool value)
    {
        isShowText = value;
    }
    public bool IsHandEnabled()
    {
        return isHandEnabled;
    }

    public void SetHandEnabled(bool value)
    {
        isHandEnabled = value;
    }

    public bool IsSoundGuilding()
    {
        return isSoundGuilding;
    }

    public void SetSoundGuilding(bool value)
    {
        isSoundGuilding = value;
    }
    public bool IsStartGame()
    {
        return isStartGame;
    }

    public void SetStartGame(bool value)
    {
        isStartGame = value;
    }
    public bool IsSoundTapHere()
    {
        return isSoundTapHere;
    }

    public void SetSoundTapHere(bool value)
    {
        isSoundTapHere = value;
    }
    public bool IsChangeLandInstruction()
    {
        return isChangeLandInstruction;
    }

    public void SetChangeLandInstruction(bool value)
    {
        isChangeLandInstruction = value;
    }
    public bool IsMoveBackground()
    {
        return isMoveBackground;
    }

    public void SetMoveBackground(bool value)
    {
        isMoveBackground = value;
    }
    public string GetClickedItem()
    {
        return clickedItem;
    }

    public void SetClickedItem(string item)
    {
        clickedItem = item;
    }

    public TextMeshProUGUI GetTextItem()
    {
        return TextItem;
    }

    public void SetTextItem(TextMeshProUGUI item)
    {
        TextItem = item;
    }

    public AudioSource GetSoundItem()
    {
        return soundItem;
    }

    public void SetSoundItem(AudioSource item)
    {
        soundItem = item;
    }
    public bool IsClickObject()
    {
        return isClickObject;
    }

    public void SetClickObject(bool value)
    {
        isClickObject = value;
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

    public string GetClickedObjectName()
    {
        return clickedObjectName;
    }

    public void SetClickedObjectName(string objName)
    {
        clickedObjectName = objName;
    }
}
