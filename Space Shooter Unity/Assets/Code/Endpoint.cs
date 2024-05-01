using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endpoint : MonoBehaviour
{
    public SpriteRenderer frontSprite;
    public SpriteRenderer backSprite;

    public Sprite inactiveFront;
    public Sprite inactiveBack;
    public Sprite activeFront;
    public Sprite activeBack;

    void SetCheckpointSprites()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Endpoint"))
        {
            Endpoint checkpoint = go.GetComponent<Endpoint>();
            checkpoint.frontSprite.sprite = checkpoint.inactiveFront;
            checkpoint.backSprite.sprite = checkpoint.inactiveBack;
        }

        frontSprite.sprite = activeFront;
        backSprite.sprite = activeBack;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SetCheckpointSprites();

            FadeManager.Instance.SetNextScene("HubWorld");
            FadeManager.Instance.SetTransition();
        }
    }
}
