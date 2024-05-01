using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship
{
    Transform target;
    public bool isGunner;

    public Sprite[] sprites;
    private bool swapSprite = false;
    public SpriteRenderer spriteRenderer;
    public int revealTime;

    //public AnimationClip[] clips;
    //private bool swapAnimation = false;
    //public Animator animator;
    public Animation animation;
    public string[] AnimationNames;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerShip>().transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerShip>())
        {
            collision.gameObject.GetComponent<PlayerShip>().TakeDamage(1);
            Explode();
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag=="Player")
        {
            Debug.Log("Spotted");
            swapSprite = true;
            Debug.Log("Swap is True");
           StartCoroutine(SpriteSwap());
            Debug.Log("Sprite Swap ACTIVATE");
            /*Echo();
            Debug.Log("Echoed Back");*/

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) 
        {
            FollowTarget();
        }

        if (isGunner && canShoot)
        {
            Shoot();
        }
    }

    void FollowTarget()
    {
        Vector2 directionToFace = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        transform.up = directionToFace;
        Thrust();
    }

    IEnumerator SpriteSwap()
    {
        Debug.Log("Enumerator active");
        if (swapSprite == true)
        {
            spriteRenderer.sprite = sprites[0];
            animation.Play(AnimationNames[0]);
            yield return new WaitForSeconds(revealTime);
            Debug.Log("spriteSwapped");
            spriteRenderer.sprite = sprites[1];
            animation.Play(AnimationNames[1]);
            swapSprite = false;
        }
    }

   

}



