using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveText : MoveByTime
{
    public GameObject frameText;
    public GameObject Text;
    public Vector3 positionFrameText;
    public Vector3 positionText;

    // Start is called before the first frame update
    public override void Start()
    {
        positionFrameText = new Vector3(-0.2f,0.1f,0);
        positionText = new Vector3(1060f,415f,10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsMoveTextEndGame() == true)
        {
            StartCoroutine(MoveSmoothly(frameText, positionFrameText, 1f));
            StartCoroutine(MoveSmoothly(Text, positionText,  1f));
            StartCoroutine(PerfromChangeColorAndSound());
            GameManager.Instance.SetMoveTextEndGame(false);
        }
    }

    public IEnumerator PerfromChangeColorAndSound()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.SetScaleTextAndFrame(true);
        yield return new WaitForSeconds(1f);
        GameManager.Instance.SetChangeColorAndSound(true);
    }
}
