using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] public AudioSource soundPodium;
    [SerializeField] public AudioSource soundYouGotACar;
    [SerializeField] public AudioSource soundChooseSuccessCar;

    protected void Update()
    {
        if(GameManager.Instance.IsPlaySoundPodium() == true)
        {
            playSoundPodium();
        }
        if (GameManager.Instance.IsPlaySoundChooseSuccess() == true)
        {
            playSoundChooseSuccess();
        }
    }
    public void playSoundPodium()
    {
        soundPodium.Play();
        GameManager.Instance.SetPlaySoundPodium(false);
    }

    public void playSoundChooseSuccess()
    {
        soundChooseSuccessCar.Play();
        soundYouGotACar.Play();
        GameManager.Instance.SetPlaySoundChooseSuccess(false);
        GameManager.Instance.SetLoadScence(true);
    }
}
