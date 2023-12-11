using System.Collections;
using UnityEngine;

public class MoveHand : MoveByTime
{
    public GameObject HandTapHere;
    public Vector3 scaleStart;
    public Vector3 scaleChange;
    public Vector3 startPosition;
    public Vector3 positionIntroLetterOne;
    public SoundTapHere soundTapHere;
    public override void Start()
    {
        timeMove = 1f;
        endPosition = new Vector3(7.6f, -1f, 0);
        startPosition = HandTapHere.transform.position;
    }

    protected void Update()
    {
        if (GameManager.Instance.IsChangeLandInstruction())
        {
            MoveHandTapHere(endPosition);
            GameManager.Instance.SetChangeLandInstruction(false);
        }
        if (GameManager.Instance.IsHandEnabled())
        {
            setReturnPosition();
        }
    }

    public void MoveHandTapHere(Vector3 endPosition)
    {
        GameManager.Instance.SetSoundTapHere(true);
        StartCoroutine(MoveSmoothly(HandTapHere, endPosition, timeMove));
    }

    public void setReturnPosition()
    {
        HandTapHere.transform.position = startPosition;
    }

    // di chuyển Hand tới vị trí của chữ mà 2 lần chưa click
    public void MoveHandInstruction(Vector3 positionLetter)
    {
        GameManager.Instance.SetHandEnabled(false);
        positionIntroLetterOne = new Vector3(transform.position.x, positionLetter.y, 0);
        MoveHandTapHere(positionIntroLetterOne);
    }
}
