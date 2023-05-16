using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Shoot : MonoBehaviour
{
    public float timeToShoot;
    float timer;

    public GameObject bulletPrefab;
    public Transform shootPoint;
    void Start()
    {
        timer = timeToShoot;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        timer = timeToShoot;
    }
}
