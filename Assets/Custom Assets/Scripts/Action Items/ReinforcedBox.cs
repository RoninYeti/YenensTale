using UnityEngine;
using System.Collections;

namespace YenensTale {
    public class ReinforcedBox : ActionItem {

        public string[] dialogue;
        public string[] emptyDialogue;
        public AudioClip reinforcedBox;
        public object aSource;

        bool interacted;

        public delegate void SwitchFlipped();
        public event SwitchFlipped switchFlipped;

        public override void Interact() {
            if (interacted)
                DialogueSystem.Instance.AddNewDialogue(emptyDialogue, "Yenen");
                //aSource.PlayOneShot(reinforcedBox);                              Fix this sound!!
            else
                DialogueSystem.Instance.AddNewDialogue(dialogue, "Yenen");
            interacted = true;

            if (switchFlipped != null) {
                switchFlipped();
            }
            //print(lightPost.BoxSwitch);
            //activate.equipRecharge();
        }
    }
}