using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Move : MonoBehaviour
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
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
        transform.LookAt(playerPosition);
    }
    
}
