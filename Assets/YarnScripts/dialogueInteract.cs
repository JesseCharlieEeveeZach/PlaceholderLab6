using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using TMPro;

public class dialogueInteract: MonoBehaviour
{
    public string nodeName; // Specify the node name you want to start from in the Inspector.
    public TextMeshProUGUI questName;
    public GameObject canvasVisibility;
    // Reference to the Dialogue Runner component in your scene.
   
    public DialogueRunner dialogueRunner;
    public LineView lineView;
    public GameObject player;
    private Transform playerTransform;
    private Transform parentTransform;
    private bool conversationStarted = false;
    private Quaternion originalRotation;


    private bool entered;
    private void Start()
    {
        entered = false;
        canvasVisibility.SetActive(false);
        // Ensure the Dialogue Runner is properly set in the Inspector.
        if (dialogueRunner == null)
        {
            Debug.LogError("Dialogue Runner is not assigned.");
        }
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        parentTransform = transform.parent;
        originalRotation = parentTransform.rotation;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            conversationStarted = false;
            canvasVisibility.SetActive(false);
            questName.text = "";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") &&  !conversationStarted && Input.GetKeyDown(KeyCode.E))
        {

            conversationStarted = true;
            // Start the dialogue with the specified node name.
            dialogueRunner.StartDialogue(nodeName);
            // Prevent starting the conversation repeatedly.
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(directionToPlayer);
            rotation *= Quaternion.Euler(0f, 0f, 0f);
            // Apply the rotation to the text
            parentTransform.rotation = rotation;

            //Taking the cheap way out
            if (nodeName == "Jim")
            {
                questName.text = "Slimes, Dimes, and Other Crimes by Zachary Dort";
                canvasVisibility.SetActive(true);
                StartCoroutine(HideCanvasAfterDelay(3.0f));
            }
            else if (nodeName == "Aria")
            {
                questName.text = "Two Dimensional Slimes by by Jesse McCormack";
                canvasVisibility.SetActive(true);
                StartCoroutine(HideCanvasAfterDelay(3.0f));
            }
            else if (nodeName == "EeveeQuest")
            {
                questName.text = "The Artifact and the Old Lady -Marie Eve Bouchard";
                canvasVisibility.SetActive(true);
                StartCoroutine(HideCanvasAfterDelay(3.0f));
            }
            else if (nodeName == "CharlieQuest")
            {
                questName.text = "Let My Horsies Go - By Charlie Sirois-Morin";
                canvasVisibility.SetActive(true);
                StartCoroutine(HideCanvasAfterDelay(3.0f));
            }
            else
            {
                canvasVisibility.SetActive(false);
                questName.text = "";
            }
        }
    }
    private void Update()
    {
        
            
        

        // Remove all player control when we're in dialogue
        if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == true)
        {
            player.GetComponent<FirstPersonController>().playerCanMove = false;
            player.GetComponent<FirstPersonController>().enableHeadBob = false;
            player.GetComponent<FirstPersonController>().enableJump = false;
            
        }
        else
        {
            conversationStarted = false;
            player.GetComponent<FirstPersonController>().playerCanMove = true;
            player.GetComponent<FirstPersonController>().enableHeadBob = true;
            player.GetComponent<FirstPersonController>().enableJump = true;
            parentTransform.rotation = originalRotation;
        }

        
      

        if (Input.GetKeyDown(KeyCode.Space))
        {
           lineView.UserRequestedViewAdvancement();

        }
        //else if (dialogueRunner.GetComponent<DialogueRunner>().IsDialogueRunning == false)
        //{
        //    Debug.Log("Thee Shall Move!");
        //    Invoke("MoveAgain", 0.1f);
        //}
    }
    private IEnumerator HideCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canvasVisibility.SetActive(false);
    }
}
