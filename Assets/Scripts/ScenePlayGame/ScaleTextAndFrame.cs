using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTextAndFrame : ScaleByTime
{
    public GameObject frameText;
    public GameObject Text;
    public Vector3 fromScaleFrame;
    public Vector3 fromScaleText;
    public Vector3 toScaleFrame;
    public Vector3 toScaleText;
    // Start is called before the first frame update
    void Start()
    {
        fromScaleFrame = frameText.transform.localScale;
        fromScaleText = Text.transform.localScale;
        toScaleFrame = new Vector3(1.7f, 1.7f, 1.7f);
        toScaleText = new Vector3(2f,2f,2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsScaleTextAndFrame() == true)
        {
            StartCoroutine(ScaleObjectCar(frameText, fromScaleFrame, toScaleFrame,1));
            StartCoroutine(ScaleObjectCar(Text, fromScaleText, toScaleText, 1));
            GameManager.Instance.SetScaleTextAndFrame(false);
        }
    }
}
