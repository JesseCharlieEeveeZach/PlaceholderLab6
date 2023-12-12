using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class EeveeQuestManager : MonoBehaviour
{
    // Start is called before the first frame update
    public VariableStorageBehaviour variableStorage;
    public GameObject artifact;
    public GameObject priestDetector;
    public bool questStart;
    void Start()
    {
        artifact.SetActive(false);
        priestDetector.SetActive(false);
        variableStorage.SetValue("$questStarted", false);
    }

    // Update is called once per frame
    void Update()
    {
        variableStorage.TryGetValue("$questStarted", out questStart);
        if (questStart)
        {
            Debug.Log("ITS BEGUN");
            artifact.SetActive(true);
            priestDetector.SetActive(true);
        }
    }
}
