using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;

    public float acceleration;
    public float maxSpeed;
    public int maxHealth;
    public float fireRate;
    public float projectileSpeed;

    public float currentSpeed;
    public int currentHealth;

    private void FixedUpdate()
    {
        if (rigidBody2D.velocity.magnitude > maxSpeed)
        { 
            rigidBody2D.velocity = rigidBody2D.velocity.normalized * maxSpeed;
        }
    }

    public void Thrust()
    {
        rigidBody2D.AddForce(transform.up * acceleration);
    }

    public void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed);
        projectile.GetComponent<Projectile>().GetFired(gameObject);
        Destroy(projectile, 4);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Explode();
        }   
    }

    public void Explode()
    { 
        Destroy(gameObject);
    }
}
