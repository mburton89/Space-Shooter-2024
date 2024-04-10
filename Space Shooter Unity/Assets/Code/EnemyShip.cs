using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship
{
    Transform target;
    

    public GameObject[] enemies;
    public GameObject homeBase;


    public bool isGunner;
    public Sprite[] sprites;
    private bool swapSprite = false;
    public SpriteRenderer spriteRenderer;
    public int revealTime;
    public int recallBird;
    PlayerShip playerShip;

    void Start()
    {
        //homeBase = GetComponent<GameObject>().; //GameObject.FindGameObjectsWithTag("HomeBase");
        GoHome();

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

    public void OnParticleCollision(GameObject other)
    {
        if (other.tag=="Player")
        {
            Debug.Log("Spotted");
            swapSprite = true;
            Debug.Log("Swap is True");
           StartCoroutine(SpriteSwap());
            Debug.Log("Sprite Swap ACTIVATE");
            StartCoroutine(FollowPlayer());
            Debug.Log("Following PLayer");
        }
    }

    void Update()
    {

        /* if (target != null)
         {
             GoHome();
         }*/

        /*if (isGunner && canShoot)
        {
            Shoot();
        }*/

        /*foreach (GameObject enemy in enemies)
        { 
            if (playerShip.CompareTag("Player"))
            {
                StartCoroutine(FollowPlayer());
            }
            else
            {
                GoHome();
            }
        }*/

       
    }


    void FollowTarget()
    {
        Vector2 directionToFace = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        transform.up = directionToFace;
        Thrust();
    }


    void GoHome()
    {
        Vector2 directionToFace = new Vector2(homeBase.transform.position.x - transform.position.x, homeBase.transform.position.y - transform.position.y);
        transform.up = directionToFace;
        Thrust();
    }



    IEnumerator SpriteSwap()
    {
        Debug.Log("Enumerator active");
        if (swapSprite == true)
        {
            spriteRenderer.sprite = sprites[0];
            yield return new WaitForSeconds(revealTime);
            Debug.Log("spriteSwapped");
            spriteRenderer.sprite = sprites[1];
            swapSprite = false;
        }
    }

    /*IEnumerator WaitForBullshit()
    {
        yield return new WaitForSeconds(recallBird);
    }*/

    IEnumerator FollowPlayer()
    {
        FollowTarget();
        yield return new WaitForSeconds(recallBird);
        GoHome();
    }

}
