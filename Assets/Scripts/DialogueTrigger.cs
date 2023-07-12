using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;
    public Vector3 targetPosition;
    private bool dialogueTriggered = false;
    public GameObject dialogueCanvas;


    void Update()
    {
        // Check if the object is at the target position
        if (transform.position == targetPosition && !dialogueTriggered)
        {
            dialogueCanvas.SetActive(true);
            // Call the dialogue function to trigger the dialogue
            StartDialogue();
            dialogueTriggered = true;
        }
    }


    public void StartDialogue()
    {
        FindObjectOfType<DialogurManager>().OpenDialogue(messages,actors);
    }
    
}


[System.Serializable]
public class Message
{
    public int actorId;
    public string message;
}

[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}