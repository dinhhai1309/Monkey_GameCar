using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTapHere : MonoBehaviour
{
    public AudioSource soundTapHere;
    public bool playSound = true;
    protected void Update()
    {
        if (GameManager.Instance.IsSoundTapHere() == true && playSound == true)
        {
            StartCoroutine(PlaySoundTapHere());
            playSound = false;
        }
    }
    public IEnumerator PlaySoundTapHere()
    {
        soundTapHere.Play();

        // Chờ đợi 5 giây
        yield return new WaitForSeconds(5f);
        playSound = true;

    }

}