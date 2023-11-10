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
            townName.text = "The Hub - Jesse McCormack - 200570287";
            canvasVisibility.SetActive(true);
            StartCoroutine(HideCanvasAfterDelay(3.0f));
        }
        if (other.CompareTag("Trafficka"))
        {
            Debug.Log(gameObject.name + " is triggered by " + other.gameObject.name);
            townName.text = "Trafficka Cult Area - Charlie Sirois-Morin 200533963";
            canvasVisibility.SetActive(true);
            StartCoroutine(HideCanvasAfterDelay(3.0f));
        }
        if (other.CompareTag("totem"))
        {
            Debug.Log(gameObject.name + " is triggered by " + other.gameObject.name);
            townName.text = "....Totem.... - Charlie Sirois-Morin 200533963";
            canvasVisibility.SetActive(true);
            StartCoroutine(HideCanvasAfterDelay(3.0f));
        }
        if (other.CompareTag("ZakkariaVille"))
        {
            Debug.Log(gameObject.name + " is triggered by " + other.gameObject.name);
            townName.text = "Sovlow City - Zachary Dort 200525761";
            canvasVisibility.SetActive(true);
            StartCoroutine(HideCanvasAfterDelay(3.0f));
        }
        if (other.CompareTag("Eevee"))
        {
            Debug.Log(gameObject.name + " is triggered by " + other.gameObject.name);
            townName.text = "Eeveeville - By Marie- Eve Bouchard 200536258";
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
