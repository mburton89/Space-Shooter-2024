using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip damageSF;
    public AudioClip echoSF;
    public Rigidbody2D rigidBody2D;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public Animator animator;
    //public GameObject projectileEchoPrefab;
    
    [SerializeField]ParticleSystem echoParticleSystem;

    public float acceleration;
    public float maxSpeed;
    public int maxHealth;
    public float fireRate;
    public float projectileSpeed;
    public GameObject explosionPrefab;

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
        rigidBody2D.AddForce(transform.up * acceleration * 20 * Time.deltaTime);
        if (thrustParticles != null)
        {
            //thrustParticles.Emit(1);
        }
    }

    public void Thrust(float strength)
    {
        rigidBody2D.AddForce(transform.up * acceleration * strength * Time.deltaTime);
        if (thrustParticles != null)
        {
            //thrustParticles.Emit(1);
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
            audio.clip = damageSF;
            audio.Play();
        }

        if (currentHealth <= 0)
        {
            Explode();
        }   
    }

    public void RegainHealth(int health)
    {
        Debug.Log("health " + health);
       if(currentHealth < maxHealth)
        {
            currentHealth += health;
            HUD.Instance.DisplayHealth(currentHealth, maxHealth);
        }

    }

    public void Explode()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        //FindObjectOfType<EnemyShipSpawner>().CountEnemyShips();

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
            echoParticleSystem.Play();
            audio.clip = echoSF;
            audio.Play();

            DarknessOverlay.Instance.Reset();
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Enemy")
        {
            //Echo();
            Debug.Log("triggered ECHO");
        }
    }

    
}
