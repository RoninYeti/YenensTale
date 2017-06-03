using UnityEngine;
using System.Collections;

public class ReinforcedBox : ActionItem
{
    public string[] dialogue;
    public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogue, "Yenen");
        Debug.Log("Interacting with Reinforced Box!");
    }
}
