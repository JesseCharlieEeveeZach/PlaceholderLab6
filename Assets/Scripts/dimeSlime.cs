using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using TMPro;

public class dimeSlime: MonoBehaviour
{
    
    public VariableStorageBehaviour variableStorage;
    public float dimeCount = 0;
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

    // Update is called once per frame
    void Update()
    {
        variableStorage.TryGetValue("$dimeSlime", out dimeSlimeStarted);
        if (dimeSlimeStarted)
        {
            if (dimeCount == 7 && Input.GetMouseButtonDown(0))
            {
                // Instantiate the dimePrefab at the shootPoint's position
                GameObject dime = Instantiate(dimePrefab, shootPoint.position, Quaternion.identity);

                // Get the rigidbody of the instantiated dime
                Rigidbody2D dimeRb = dime.GetComponent<Rigidbody2D>();

                if (dimeRb != null)
                {
                    // Calculate the shooting direction
                    Vector2 shootDirection = new Vector2(1, 1);

                    // Apply force to shoot the dimePrefab in an arc
                    dimeRb.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
                }

                // Decrease the dimeCount
                dimeCount--;

                // Update the dimeCounter text
                dimeCounter.text = "Dimes: " + dimeCount.ToString();
            }
        }
    }
}
