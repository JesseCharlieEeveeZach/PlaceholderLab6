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
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        variableStorage.TryGetValue("$artifactCollected", out hasArtifact);
        if (collision.CompareTag("artifact") && !hasArtifact)
        {
            collision.gameObject.SetActive(false);
            hasArtifact = true;
            variableStorage.SetValue("$artifactCollected", true);
        }
    }


}
