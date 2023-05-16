using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Move : MonoBehaviour
{
    public Transform player;
    private Vector3 playerPosition;
    public float speed;

    void Update()
    {
        Move();
    }

    void Move()
    {
        playerPosition = player.position;
        Vector3 direction = transform.position - playerPosition;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        transform.LookAt(playerPosition);
    }
}

