using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCoutDown : MonoBehaviour
{
    public GameManager gameManager;
    public AudioSource soundCountDown;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.IsSoundCountDown()== true)
        {
            PlaySoundCountDown();
        }
    }

    public void PlaySoundCountDown()
    {
        soundCountDown.Play();
        GameManager.Instance.SetSoundCountDown(false);

    }
}
