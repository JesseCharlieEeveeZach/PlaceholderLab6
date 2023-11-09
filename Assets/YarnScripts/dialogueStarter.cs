using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class dialogueStarter : MonoBehaviour
{
    public string nodeName; // Specify the node name you want to start from in the Inspector.

    // Reference to the Dialogue Runner component in your scene.
    
    public DialogueRunner dialogueRunner;
    public LineView lineView;
    public GameObject player;

    private bool conversationStarted = false;

    private void Start()
    {
        // Ensure the Dialogue Runner is properly set in the Inspector.
        if (dialogueRunner == null)
        {
            Debug.LogError("Dialogue Runner is not assigned.");
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !conversationStarted && Input.GetKeyDown(KeyCode.E))
        {
            
            player.GetComponent<FirstPersonController>().playerCanMove = false;
            player.GetComponent<FirstPersonController>().enableHeadBob = false;
            player.GetComponent<FirstPersonController>().enableJump = false;
            // Start the dialogue with the specified node name.
            dialogueRunner.StartDialogue(nodeName);
            conversationStarted = true; // Prevent starting the conversation repeatedly.
        }
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lineView.UserRequestedViewAdvancement();
            
        }
    }

}
