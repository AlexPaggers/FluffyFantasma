using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    [SerializeField]
    Text entityName;
    [SerializeField]
    Text dialogueText;

    private Queue<string> currentDialogue;
    // Use this for initialization
    void Start()
    {
        currentDialogue = new Queue<string>();
    }

    public void sendDialogue(Dialogue dialogue)
    {
        GameData.Dialogue = true;
        Debug.Log("Sending dialogue of " + dialogue.EntityName);

        currentDialogue.Clear();
        foreach(string sentence in dialogue.EntityDialogue)
        {
            currentDialogue.Enqueue(sentence);
        }

        sendNextDialogue();
    }

    public void sendNextDialogue()
    {
        if(currentDialogue.Count == 0)
        {
            endDialogue();
            return;
        }

        string s  = currentDialogue.Dequeue();
        dialogueText.text = s;
        Debug.Log(s);
    }

    public void endDialogue()
    {
        GameData.Dialogue = false;
        Debug.Log("Dialogue ended.");
    }
}