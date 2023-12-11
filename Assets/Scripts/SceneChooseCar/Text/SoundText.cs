using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundText : MonoBehaviour
{
    [SerializeField] public AudioSource soundTapAChoose;
    private void Update()
    {
        if(GameManager.Instance.IsPlaySoundText() == true)
        {
            playSound();
        }
    }
    public void playSound()
    {
        soundTapAChoose.Play();
        GameManager.Instance.SetPlaySoundText(false);
    }
}
