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
        if (other.CompareTag("TheHub"))
        {
            Debug.Log(gameObject.name + " is triggered by " + other.gameObject.name);
            townName.text = "The Hub";
            canvasVisibility.SetActive(true);
        }
        if (other.CompareTag("Trafficka"))
        {
            Debug.Log(gameObject.name + " is triggered by " + other.gameObject.name);
            townName.text = "Trafficka Cult Area";
            canvasVisibility.SetActive(true);
        }
        if (other.CompareTag("totem"))
        {
            Debug.Log(gameObject.name + " is triggered by " + other.gameObject.name);
            townName.text = "....Totem....";
            canvasVisibility.SetActive(true);
        }
        if (other.CompareTag("ZakkariaVille"))
        {
            Debug.Log(gameObject.name + " is triggered by " + other.gameObject.name);
            townName.text = "ZakkariaVille";
            canvasVisibility.SetActive(true);
            StartCoroutine(HideCanvasAfterDelay(3.0f));
        }
        if (other.CompareTag("Eevee"))
        {
            Debug.Log(gameObject.name + " is triggered by " + other.gameObject.name);
            townName.text = "Eeveeville";
            canvasVisibility.SetActive(true);
            StartCoroutine(HideCanvasAfterDelay(3.0f));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        townName.text = "";
        if (canvasVisibility.activeInHierarchy)
        {
            canvasVisibility.SetActive(false);
        }
        else
        {
            Debug.Log("Canvas hidden already!");
        }
    }

    private IEnumerator HideCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canvasVisibility.SetActive(false);
    }
}
