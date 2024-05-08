using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLooper : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public List<Sprite> defaultSprites;

    public float secondsBetweenFrames = 0.15f;

    void Start()
    {
        StartCoroutine(LoopIdle());
    }

    private IEnumerator LoopIdle()
    {
        for (int i = 0; i < defaultSprites.Count; i++)
        {
            spriteRenderer.sprite = defaultSprites[i];
            yield return new WaitForSeconds(secondsBetweenFrames);
        }

        StartCoroutine(LoopIdle());
    }
}
