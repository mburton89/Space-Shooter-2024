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

        Debug.Log("Mosquito Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);

        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerShip>().RegainHealth(1);
           
            SoundFXManager.Instance.PlaySoundFXClip(collect, transform, collectVolume);   

            this.gameObject.SetActive(false);
            Destroy(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerShip>().RegainHealth(1);

            SoundFXManager.Instance.PlaySoundFXClip(collect, transform, collectVolume);

            this.gameObject.SetActive(false);
            Destroy(this);
        }
    }
}
