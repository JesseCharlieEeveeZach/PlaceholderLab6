using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class playerDetector : MonoBehaviour
{
    // Start is called before the first frame update

    public VariableStorageBehaviour variableStorage;
    public Transform restart;
    public bool playerHasArtifact;
    public GameObject artifact;


    void Start()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {

        variableStorage.TryGetValue("$artifactCollected", out playerHasArtifact);


        if (other.CompareTag("Player"))
        {
            other.transform.position = restart.transform.position;
            Debug.Log("Sent back");

            if (playerHasArtifact)
            {
                variableStorage.SetValue("$artifactCollected", false);
                artifact.SetActive(true);
            }

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
