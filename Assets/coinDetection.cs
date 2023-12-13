using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class coinDetection : MonoBehaviour
{

    public VariableStorageBehaviour variableStorage;
    public dimeTracker dimetracks; 
    // Start is called before the first frame update
    void Start()
    {
        dimetracks = GetComponent<dimeTracker>();
    }


    private void OnTriggerEnter(Collider other)
    {
        Destroy(other);
        dimetracks.dimeCount += 1;
        Debug.Log(dimetracks.dimeCount);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
