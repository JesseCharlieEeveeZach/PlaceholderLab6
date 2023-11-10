using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class dialogueInteract: MonoBehaviour
{
    public string nodeName; // Specify the node name you want to start from in the Inspector.

    // Reference to the Dialogue Runner component in your scene.

    public DialogueRunner dialogueRunner;
    public LineView lineView;
    public GameObject player;
    private Transform playerTransform;
    private Transform parentTransform;
    private bool conversationStarted = false;
    private Quaternion originalRotation;

    private void Start()
    {
       
        // Ensure the Dialogue Runner is properly set in the Inspector.
        if (dialogueRunner == null)
        {
            Debug.LogError("Dialogue Runner is not assigned.");
        }
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        parentTransform = transform.parent;
        originalRotation = parentTransform.rotation;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !conversationStarted && Input.GetKeyDown(KeyCode.E))
        {

            
            // Start the dialogue with the specified node name.
            dialogueRunner.StartDialogue(nodeName);
            conversationStarted = true; // Prevent starting the conversation repeatedly.
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(directionToPlayer);
            rotation *= Quaternion.Euler(0f, 0f, 0f);
            // Apply the rotation to the text
            parentTransform.rotation = rotation;
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
    
}
