using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

    public string entityName;
    [TextArea(1, 3)]
    public string[] entityDialogue;

    public string EntityName
    {
        get
        {
            return entityName;
        }
    }

    public string[] EntityDialogue
    {
        get
        {
            return entityDialogue;
        }
    }
}
