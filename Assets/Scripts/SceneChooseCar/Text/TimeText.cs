using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeText : TimeManager
{
    public TextScaling TextScaling;
    public SoundText soundText;

    public void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();
    }

    public override bool CheckElapsedTime()
    {
        return elapsedTime >= 2.5;
    }

    public override void PerformAction()
    {
        TextScaling.ScaleText();
        StartCoroutine(delayTimeToMove());
    }

    public IEnumerator delayTimeToMove()
    {
        yield return new WaitForSeconds(1f);
        TextScaling.ScaleTextOne();
        soundText.playSound();
    }
}
