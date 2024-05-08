using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Moth : Ship
{
    public float secondsToRecall = 4f;
    Vector3 startingPosition;

    bool shouldFlee;

    Transform target;

    void Start()
    {
        target = FindObjectOfType<PlayerShip>().transform;
        startingPosition = transform.position;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Player" && shouldFlee == false)
        {
            shouldFlee = true;
            StartCoroutine(FleeBuffer());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerShip>())
        {
            collision.gameObject.GetComponent<PlayerShip>().TakeDamage(1);
            Explode();
        }
    }

    void Update()
    {
        if (shouldFlee)
        {
            RunAway();
        }
        else
        {
            GoHome();
        }
    }

    void RunAway()
    {
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

    IEnumerator FleeBuffer()
    {
        yield return new WaitForSeconds(secondsToRecall);
        shouldFlee = false;
    }
}
