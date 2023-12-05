using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportRandom : MonoBehaviour
{
    public Transform[] teleportLocations; // Array of possible teleport locations
    private Transform playerTransform;     // Reference to the player's transform

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = other.transform; // Store a reference to the player's transform
            TeleportPlayerRandomly();
        }
    }

    private void TeleportPlayerRandomly()
    {
        if (teleportLocations.Length > 0 && playerTransform != null)
        {
            // Choose a random index from the array
            int randomIndex = Random.Range(0, teleportLocations.Length);

            // Teleport the player to the chosen location
            playerTransform.position = teleportLocations[randomIndex].position;
        }
        else
        {
            Debug.LogWarning("No teleport locations set or player transform not found!");
        }
    }
}
