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

        currentDialogue.Clear();

        if(dialogue.entityDialogue.Length > 0)
        {
            Debug.Log("Dialogue: " + dialogue.entityDialogue);
            dialogueText.text = dialogue.entityDialogue;
        }
            
    }
}