using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using TMPro;

public class dimeSlime : MonoBehaviour
{
    public VariableStorageBehaviour variableStorage;
    public int dimeCount = 7;
    public GameObject dimePrefab;
    public TextMeshProUGUI dimeCounter;
    public GameObject dimeDisplay;
    public Transform shootPoint;
    public bool dimeSlimeStarted;
    public float shootForce = 10f;

    void Start()
    {
        dimeCounter.text = "";
    }

    void Update()
    {
        variableStorage.TryGetValue("$dimeSlime", out dimeSlimeStarted);

        if (dimeSlimeStarted)
        {
            dimeDisplay.SetActive(true);
            dimeCounter.text = "Dimes: " + dimeCount.ToString();

            if (Input.GetMouseButtonDown(0) && dimeCount > 0)
            {
                // Instantiate the dimePrefab at the shootPoint's position
                GameObject dime = Instantiate(dimePrefab, shootPoint.position, Quaternion.identity);

                // Get the rigidbody of the instantiated dime
                Rigidbody dimeRb = dime.GetComponent<Rigidbody>();

                if (dimeRb != null)
                {
                    // Use the forward direction of the shootPoint as the shooting direction
                    Vector3 shootDirection = shootPoint.forward;

                    // Apply force to shoot the dimePrefab in the calculated direction
                    dimeRb.AddForce(shootDirection * shootForce, ForceMode.Impulse);
                }

                // Decrease the dimeCount
                dimeCount--;

                // Update the dimeCounter text
                dimeCounter.text = "Dimes: " + dimeCount.ToString();
            }
        }
        else
        {
            dimeDisplay.SetActive(false);
        }
    }
}
