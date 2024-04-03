using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    //public GameObject projectileEchoPrefab;
    
    [SerializeField]ParticleSystem echoParticleSystem;

    public float acceleration;
    public float maxSpeed;
    public int maxHealth;
    public float fireRate;
    public float projectileSpeed;

    public float currentSpeed;
    [HideInInspector] public int currentHealth;

    ParticleSystem thrustParticles;

    public bool canShoot;

    private void Awake()
    {
        thrustParticles = GetComponentInChildren<ParticleSystem>();
        currentHealth = maxHealth;
        canShoot = true;
    }

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
        if (thrustParticles != null)
       { 
            thrustParticles.Emit(1);
        }
    }

    private IEnumerator CoolDown() 
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    public void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed);
        projectile.GetComponent<Projectile>().GetFired(gameObject);
        Destroy(projectile, 4);
        StartCoroutine(CoolDown());
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (GetComponent<PlayerShip>())
        { 
            HUD.Instance.DisplayHealth(currentHealth, maxHealth);
        }

        if (currentHealth <= 0)
        {
            Explode();
        }   
    }

    public void Explode()
    {
        Instantiate(Resources.Load("Explosion"), transform.position, transform.rotation);

        FindObjectOfType<EnemyShipSpawner>().CountEnemyShips();

        if (GetComponent<PlayerShip>())
        {
            GameManager.Instance.GameOver();
        }

        Destroy(gameObject);
    }

    public void Echo()
    {
        if (echoParticleSystem != null)
        {
            Debug.Log("Echo1");
            echoParticleSystem.Play();
        }
        Debug.Log("Echoed");
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("triggered ECHO");
        }
    }
}
