using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Adjust the rotation speed as needed
    public float rotationSpeed = 30f;

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around the Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
