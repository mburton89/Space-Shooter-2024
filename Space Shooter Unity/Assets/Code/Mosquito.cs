using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosquito : MonoBehaviour
{
    public GameManager gameManager;
    public AudioSource mosquitoAudio;
    public AudioSource UniversalSound;
    public AudioClip buzz;
    public AudioClip collect;
    public float collectVolume;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        mosquitoAudio.clip = buzz;
        mosquitoAudio.spatialBlend = 1;
        mosquitoAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            if (gameManager.dashBarValue <= .66f)
            {
                gameManager.dashBarValue += .33f;
            }
            else if (gameManager.dashBarValue > .66f)
            {
                gameManager.dashBarValue = 1;
            }


            SoundFXManager.Instance.PlaySoundFXClip(collect, transform, .2f);   

            this.gameObject.SetActive(false);
            Destroy(this);
        }
    }
}
