using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Ship
{
    bool reactToEcho;
    public float secondsToRecall = 4f;

    Transform target;
    Vector3 startingPosition;

    public bool isMoth;

    void Start()
    {
        target = FindObjectOfType<PlayerShip>().transform;
        startingPosition = transform.position;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Player" && reactToEcho == false)
        {
            reactToEcho = true;
            StartCoroutine(GoHomeBuffer());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerShip>())
        {
            if (isMoth)
            {
                HUD.Instance.AddPoint(1);
            }
            else
            {
                collision.gameObject.GetComponent<PlayerShip>().TakeDamage(1);
            }
            Explode();
        }
    }

    void Update()
    {
        if (reactToEcho)
        {
            if (isMoth)
            {
                RunAway();
            }
            else
            { 
                FollowTarget();
            }
        }
        else
        { 
            GoHome();
        }
    }

    void FollowTarget()
    {
        if (target == null) return; 

        Vector2 directionToFace = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        transform.up = directionToFace;
        Thrust();
    }

    void RunAway()
    {
        if (target == null) return;
        Vector2 directionToFace = new Vector2(target.position.x + transform.position.x, target.position.y + transform.position.y);
        transform.up = directionToFace;
        Thrust();
    }

    void GoHome()
    {
        if (Vector2.Distance(startingPosition, transform.position) > 1f)
        {
            Vector2 directionToFace = new Vector2(startingPosition.x - transform.position.x, startingPosition.y - transform.position.y);
            transform.up = directionToFace;
            Thrust();
        }
    }

    IEnumerator GoHomeBuffer()
    {
        yield return new WaitForSeconds(secondsToRecall);
        reactToEcho = false;
    }
}

