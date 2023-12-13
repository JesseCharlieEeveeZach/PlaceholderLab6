using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class dimeTracker : MonoBehaviour
{
    // Start is called before the first frame update

    public int dimesSlimed = 0;
    public VariableStorageBehaviour variableStorage;
    public bool questDone;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dimesSlimed >= 7)
        {
            variableStorage.SetValue("$slimesDimed", true);
            variableStorage.SetValue("$dimeSlime", false);
        }
    }
}
