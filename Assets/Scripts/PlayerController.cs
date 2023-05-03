using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the player and the powerup
// Attach this script to the player

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Speed of player
    public bool hasPowerup; // Whether or not the player has a powerup
    public float powerupStrength = 15.0f; // How strong the powerup is

    public GameObject powerupIndicator; // Reference to the powerup indicator

    private GameObject focalPoint; // Reference to the focal point
    private Rigidbody playerRb; // Reference to the rigidbody component

    // Start is called before the first frame update
    void Start()
    {
        // Get the rigidbody component
        playerRb = GetComponent<Rigidbody>();

        // Get the focal point
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        // Get the vertical input to move the player forward
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        // Set the position of the powerup indicator to the player's position
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    // OnTriggerEnter is called when the player collides with a trigger
    private void OnTriggerEnter(Collider other)
    {
        // If the player collides with a powerup
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision other) // This method is called when the player collides with an object
    {
        // If the player collides with an enemy and has a powerup
        if (other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            // Get the enemy's rigidbody
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();

            // Add force to the enemy in the direction away from the player
            Debug.Log("Collided with " + other.gameObject.name + " with powerup set to " + hasPowerup);
            enemyRb.AddForce((other.gameObject.transform.position - transform.position).normalized * powerupStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine() // This method is called when the player collides with a powerup
    {
        // Wait 7 seconds
        yield return new WaitForSeconds(7);

        // Set hasPowerup to false
        hasPowerup = false;

        // Set the powerup indicator to false
        powerupIndicator.gameObject.SetActive(false);
    }
}
