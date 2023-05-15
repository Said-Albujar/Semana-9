using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour, IDamage, IObserver
{
    [SerializeField]
    private float initialDamage;

    [SerializeField]
    private float initialSpeed;

    [SerializeField]
    private float initialHealth;

    private float currentDamage;
    private float currentSpeed;
    private float currentHealth;
    private Rigidbody rb;
    private Transform playerTransform;
    private float fireRate = 1f;
    private float nextFireTime = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        GameManager.GetInstance().Attach(this);

        currentDamage = initialDamage;
        currentSpeed = initialSpeed;
        currentHealth = initialHealth;
    }

    public float GetDamage()
    {
        return currentDamage;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (playerTransform != null)
        {
           
            Vector3 direction = transform.position - playerTransform.position;
            rb.velocity = direction.normalized * currentSpeed;

            
            if (Time.time > nextFireTime)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<BulletController>().SetDirection(direction.normalized);

                nextFireTime = Time.time + 1f / fireRate;
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    public void Execute(ISubject subject)
    {
        if (subject is GameManager)
        {
            GameManager gameManager = (GameManager)subject;

           
            currentDamage = initialDamage + gameManager.GetElapsedTime();
            currentSpeed = initialSpeed + gameManager.GetElapsedTime();
            fireRate = 1f + gameManager.GetElapsedTime();

           
            playerTransform = gameManager.GetPlayerTransform();
        }
    }
}

