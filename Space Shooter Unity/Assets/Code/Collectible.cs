using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public bool refuelBoost;

    public AudioClip collectSound;
    public float collectVolume = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerShip>())
        {
            GetCollected();
        }
    }

    void GetCollected()
    {
        if (refuelBoost)
        {
            if (GameManager.Instance.dashBarValue <= .66f)
            {
                GameManager.Instance.dashBarValue += .33f;
            }
            else if (GameManager.Instance.dashBarValue > .66f)
            {
                GameManager.Instance.dashBarValue = 1;
            }

            HUD.Instance.DisplayDashAmount(GameManager.Instance.dashBarValue, 1);
        }
        
        SoundFXManager.Instance.PlaySoundFXClip(collectSound, transform, collectVolume);

        Destroy(gameObject);
    }
}
