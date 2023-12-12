using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CollectArtifact : MonoBehaviour
{
    public bool hasArtifact = false;
    public VariableStorageBehaviour variableStorage;

    private void Start()
    {
        
    }

    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("artifact") && !hasArtifact)
        {
            Destroy(collision.gameObject);
            hasArtifact = true;
            variableStorage.SetValue("$artifactCollected", true);
        }
    }


}
