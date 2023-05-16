using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Bullet : MonoBehaviour
{
    protected Rigidbody rb;
    public GameObject player;
    public float bulletSpeed;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected virtual void Update()
    {
        rb.velocity = (player.transform.position - transform.position).normalized * 10;
        //transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }
    
}
