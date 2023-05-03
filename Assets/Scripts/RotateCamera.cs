using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script rotates the camera around the player
// Attach this script to the Main Camera

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed; // Speed of rotation

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal input to rotate the camera
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
