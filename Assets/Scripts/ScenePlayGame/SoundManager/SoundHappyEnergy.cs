using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHappyEnergy : MonoBehaviour
{
    public AudioSource soundHappyEnergy;

    public void PlaySound()
    {
        soundHappyEnergy.Play();
    }
}
