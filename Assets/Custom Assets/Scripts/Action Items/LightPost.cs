using UnityEngine;
using System.Collections;

public class LightPost : ActionItem
{
    public string[] dialogue;
    public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogue, "Yenen");
        Debug.Log("Interacting with Light Post!");
    }
}
