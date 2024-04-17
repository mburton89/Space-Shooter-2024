using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship
{
    Transform target;

    public GameManager manager;
    

    public GameObject owlHomeBase;

    public GameObject[] MothSpots;

    private bool particalHit = false;

    public bool isGunner;
    public Sprite[] sprites;
    private bool swapSprite = false;
    public SpriteRenderer spriteRenderer;
    public int revealTime;
    public int recallBird = 3;

    public bool isMoth;
    public bool isOwl;

    private int whichSpot = 0;

    void Start()
    {
        manager = FindAnyObjectByType<GameManager>();
        //homeBase = GetComponent<GameObject>().; //GameObject.FindGameObjectsWithTag("HomeBase");
        GoHome();

        target = FindObjectOfType<PlayerShip>().transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerShip>() && isOwl)
        {
            collision.gameObject.GetComponent<PlayerShip>().TakeDamage(1);
            Explode();
        }
        else if (collision.gameObject.GetComponent<PlayerShip>() && isMoth)
        {
            manager.mothsGotten += 1;
            Debug.Log(manager.mothsGotten);
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
            particalHit = true;
            Debug.Log("Following PLayer");
        }
    }

    void Update()
    {
        if(particalHit && isOwl)
        {
            FollowTarget();
            StartCoroutine(FollowPlayer());
        }
        else if (particalHit && isMoth)
        {
            runAway();
            StartCoroutine(RunAway());
        }
        else if (isOwl)
        {
            GoHome();
        }
        else if (isMoth)
        {
            
            MothGoHome();
        }
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

    void runAway()
    {
        Vector2 directionToFace = new Vector2(target.position.x + transform.position.x, target.position.y + transform.position.y);
        transform.up = directionToFace;
        Thrust();
    }


    void GoHome()
    {
        Vector2 directionToFace = new Vector2(owlHomeBase.transform.position.x - transform.position.x, owlHomeBase.transform.position.y - transform.position.y);
        transform.up = directionToFace;
        Thrust();
    }

    void MothGoHome()
    {
        Vector2 directionToFace = new Vector2(MothSpots[whichSpot].transform.position.x - transform.position.x, MothSpots[whichSpot].transform.position.y - transform.position.y);
        transform.up = directionToFace;
        Thrust();
    }



    IEnumerator SpriteSwap()
    {
        Debug.Log("Enumerator active");
        if (swapSprite == true)
        {
            if (whichSpot >= MothSpots.Length)
            {
                whichSpot = 0;
            }
            else
            {
                whichSpot += 1;
                Debug.Log(whichSpot);
            }
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
        yield return new WaitForSeconds(recallBird);
        particalHit = false;
    }

    IEnumerator RunAway()
    {
        yield return new WaitForSeconds(recallBird);
        
        particalHit = false;
    }

}
