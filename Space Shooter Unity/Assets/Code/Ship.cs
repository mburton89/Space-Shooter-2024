using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    public GameObject projectile;
    public Transform projectileSpawnPoint;

    public float acceleration;
    public float maxSpeed;
    public int maxHealth;
    public float fireRate;
    public float projectileSpeed;

    public float currentSpeed;
    public int currentHealth;

    public void Thrust()
    {
        rigidBody2D.AddForce(Vector2.up * acceleration);
    }

    public void Shoot()
    { 
    
    }

    public void TakeDamage()
    { 
    
    }

    public void Explode()
    { 
    
    }
}
