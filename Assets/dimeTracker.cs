using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class dimeTracker : MonoBehaviour
{
    // Start is called before the first frame update

    public int dimeCount;
    public VariableStorageBehaviour variableStorage;
    public bool questDone;

    void Start()
    {
        dimeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(dimeCount >= 7)
        {
            variableStorage.SetValue("$slimesDimed", true);
            variableStorage.SetValue("$dimeSlime", false);
        }
    }
}
