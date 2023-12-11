using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAudience : MonoBehaviour
{
    public AudioSource soundAudienceHappy;
    public AudioSource soundAudienceDis;

    public bool isPlaySound = true;
    public bool isPlaySoundDis = true;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsSoundAudienceHappy()==true && GameManager.Instance.IsSoundAudienceHappySecond() == true)
        {
            PlaySoundAudienceHappy();
            GameManager.Instance.SetSoundAudienceHappySecond(false);
        }
        if (GameManager.Instance.IsSoundAudienceDisapointed() == true )
        {
            PlaySoundAudienceDis();
            GameManager.Instance.SetSoundAudienceDisapointed(false);
        }
    }

    public void PlaySoundAudienceHappy()
    {
        soundAudienceHappy.Play();       
    }

    public void PlaySoundAudienceDis()
    {
        soundAudienceDis.Play();
    }
}
