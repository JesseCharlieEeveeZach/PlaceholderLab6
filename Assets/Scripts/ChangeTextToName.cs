using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeTextToName : MonoBehaviour
{
    private TextMeshPro textMeshPro; // Reference to the TextMeshPro component

    void Start()
    {
        // Get the TextMeshPro component on the current GameObject
        textMeshPro = GetComponent<TextMeshPro>();

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
}

