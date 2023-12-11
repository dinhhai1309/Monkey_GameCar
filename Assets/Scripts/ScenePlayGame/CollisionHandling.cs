using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandling: MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsColliderLetter() == true )
        {
            GameManager.Instance.SetCheckMoveAudience(true);
            GameManager.Instance.SetMoveAudience(true);
            GameManager.Instance.SetSoundAudienceHappy(true); // bật âm thanh khán giả vui mừng
            GameManager.Instance.SetSoundColliderText(true);// bật âm thanh chữ va chạm
            GameManager.Instance.SetSoundTextAndItem(true);
            GameManager.Instance.SetMoveArcLetter(true); // di chuyển chữ khi va chạm
            GameManager.Instance.SetShowText(false);
            GameManager.Instance.SetSoundAudienceHappySecond(true);
            GameManager.Instance.SetChangeAudienceHappy(true);
            GameManager.Instance.SetColliderLetter(false);
        }
    }
}
