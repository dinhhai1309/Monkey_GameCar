using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAudienceCheerece : MonoBehaviour
{
    public AudioSource soundCheerece;
    public AudioSource soundAudienceCheerece;

    public bool sound = true;
    // Update is called once per frame
    void Update()
    {
       if(GameManager.Instance.IsSoundCheere()== true)
        {
            soundCheerece.Stop();
        }
        if (GameManager.Instance.IsSoundAudiecneCheere() == true && sound )
        {
            soundAudienceCheerece.Play();
            Debug.Log("baajt sount cheere");
            sound = false;
        }
    }
}
