using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int pointsToGive = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerShip>())
        {
            GetCollected();
        }
    }

    void GetCollected()
    {
        HUD.Instance.AddPoint(pointsToGive);
        Destroy(gameObject);
    }
}
