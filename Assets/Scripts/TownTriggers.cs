using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TownTriggers : MonoBehaviour
{
    public TextMeshProUGUI townName;
    public GameObject canvasVisibility;


    // Start is called before the first frame update
    void Start()
    {
        canvasVisibility.SetActive(false);
        townName.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TownTrigger"))
        {
            Debug.Log(gameObject.name + " is triggered by " + other.gameObject.name);
            townName.text = "The Hub";
            canvasVisibility.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        townName.text = "";
        canvasVisibility.SetActive(false);
    }


}
