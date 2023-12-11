using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCoutDown : MonoBehaviour
{
    public AudioSource soundCountDown;
    public SoundHappyEnergy soundHappyEnergy;
    private void Start()
    {
        StartCoroutine(PlaySoundCountDown());

    }

    public IEnumerator  PlaySoundCountDown()
    {
        yield return new WaitForSeconds(6f);
        GameManager.Instance.SetSoundCheere(true);
        soundCountDown.Play();
        yield return new WaitForSeconds(4f);
        soundCountDown.Stop();
        soundHappyEnergy.PlaySound();
    }
}
