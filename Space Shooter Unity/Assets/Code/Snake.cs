using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;
    public Transform collisionBox;

    public float secondsBetweenAttacks;
    public float secondsBetweenFrames;
    public float movementSpeed;
    public float maxYPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AnimateCo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator AttackCo()
    {
        yield return new WaitForSeconds(secondsBetweenAttacks);
    }

    private IEnumerator AnimateCo() 
    {
        for (int i = 0; i < sprites.Length; i++) 
        {
            spriteRenderer.sprite = sprites[i];
            yield return new WaitForSeconds(secondsBetweenFrames);
        }

        yield return new WaitForSeconds(secondsBetweenAttacks);

        StartCoroutine(AnimateCo());
    }
}
