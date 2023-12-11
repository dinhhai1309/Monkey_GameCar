using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundColliderPowr : MonoBehaviour
{
    public AudioSource soundPlusSpeed;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.IsCheckColliderPower()==true && GameManager.Instance.IsPlaySoundPlusSpeed() == true)
        {
            GameManager.Instance.SetPlaySoundPlusSpeed(false);
            soundPlusSpeed.Play();
        }
    }
}
