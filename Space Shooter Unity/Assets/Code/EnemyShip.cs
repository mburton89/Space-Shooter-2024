using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship
{
    Transform target;
    Transform home;
    public bool isGunner;

    void Start()
    {
        home = FindObjectOfType<HomeBase>().transform;
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

    void Update()
    {
        //if Bat uses echolocation, switch target to Bat call FollowTarget

        //if Bat takes one damage, switch target to home base and return


        if (target != null)
        {
            GoHome();
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

    void GoHome()
    {
        Vector2 directionToFace = new Vector2(home.position.x - transform.position.x, home.position.y - transform.position.y);
        transform.up = directionToFace;
        Thrust();
    }
}
