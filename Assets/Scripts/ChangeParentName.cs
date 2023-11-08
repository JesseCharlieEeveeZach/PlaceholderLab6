using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeParentName : MonoBehaviour
{
    private TextMeshPro textMeshPro; // Reference to the TextMeshPro component
    private Transform playerTransform;
    void Start()
    {
        // Get the TextMeshPro component on the current GameObject
        textMeshPro = GetComponent<TextMeshPro>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshPro component not found on this GameObject.");
            return;
        }

        // Get the parent GameObject
        Transform parent = transform.parent;

        if (parent == null)
        {
            Debug.LogError("No parent GameObject found.");
            return;
        }

        // Change the TextMeshPro text to match the name of the parent GameObject
        textMeshPro.text = parent.name;
    }

    private void Update()
    {
        Vector3 directionToPlayer = playerTransform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(directionToPlayer);
        rotation *= Quaternion.Euler(0f, 180f, 0f);
        // Apply the rotation to the text
        transform.rotation = rotation;
    }
}

