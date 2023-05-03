using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script makes the enemy move towards the player
// Attach this script to the enemy prefab

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f; // Speed of enemy
    
    private Rigidbody enemyRb; // Reference to the rigidbody component
    private GameObject player; // Reference to the player object

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

        // Move the enemy towards the player
        enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);
    }
}
