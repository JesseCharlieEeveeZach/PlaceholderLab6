using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class coinDetection : MonoBehaviour
{
    public VariableStorageBehaviour variableStorage;
    public dimeTracker manager; // Assuming dimeTracker is the correct class name

    // Start is called before the first frame update
    void Start()
    {
     

        
        manager = GameObject.FindWithTag("ZachQuestManager").GetComponent<dimeTracker>();

        // Ensure that the dimeTracker component is not null before using it
        if (manager == null)
        {
            Debug.LogError("dimeTracker component not found on the player object.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Assuming you want to destroy the coin and increment the dime count
        if (other.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            manager.dimesSlimed += 1;
            Debug.Log(manager.dimesSlimed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update logic here
    }
}
