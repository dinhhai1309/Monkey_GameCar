using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundGuilding : MonoBehaviour
{
    public AudioSource soundGuilding;
    public GameManager gameManager;
    public bool soundOne = true;
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.IsSoundGuilding()== true && soundOne==true)
        {
           PlaySound();
            soundGuilding.Play();
            soundOne = false;
        }
        if (GameManager.Instance.IsSoundGuilding() == true && GameManager.Instance.IsPhonicSecond() == true)
        {
            PlaySound();
        }
    }

    public void PlaySound()
    {
        GameManager.Instance.SetSoundGuilding(false);
        StartCoroutine(StartGame());
        GameManager.Instance.SetCompleteInstruction(true);
        GameManager.Instance.SetStartGame(true);
    }

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(7f);
    }
}
