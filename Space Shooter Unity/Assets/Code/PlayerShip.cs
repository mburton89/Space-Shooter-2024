using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Thrust();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        FollowMouse();
    }

    void FollowMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        Vector2 directionToFace = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = directionToFace;
    }
}
