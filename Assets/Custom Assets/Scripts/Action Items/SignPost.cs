using UnityEngine;
using System.Collections;

namespace YenensTale
{
    public class SignPost : ActionItem
    {
        public string[] dialogue;
        public override void Interact()
        {
            DialogueSystem.Instance.AddNewDialogue(dialogue, "Yenen");
            Debug.Log("Interacting with sign post!");
        }
    }
}