using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDialogue : MonoBehaviour {

    public Dialogue dialogue;

    public void DialogueTrigger()
    {
        FindObjectOfType<DialogueManager>().sendDialogue(dialogue);
    }
}
