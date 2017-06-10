using UnityEngine;
using System.Collections;

namespace YenensTale
{
    public class ReinforcedBox : ActionItem
    {
        public string[] dialogue;
        public string[] emptyDialogue;

        bool interacted;

        public delegate void SwitchFlipped();
        public event SwitchFlipped switchFlipped;

        public override void Interact()
        {
            if (interacted)
                DialogueSystem.Instance.AddNewDialogue(emptyDialogue, "Yenen");
            else
                DialogueSystem.Instance.AddNewDialogue(dialogue, "Yenen");
            interacted = true;
            Debug.Log("Interacting with Reinforced Box!");
            if (switchFlipped != null)
            {
                switchFlipped();
            }
            //print(lightPost.BoxSwitch);
            //activate.equipRecharge();

        }
    }
}