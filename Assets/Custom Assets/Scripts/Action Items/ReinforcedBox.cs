using UnityEngine;
using System.Collections;

namespace YenensTale {
    public class ReinforcedBox : ActionItem {

        public string[] dialogue;
        public string[] emptyDialogue;

        public AudioSource aSource;
        public AudioClip reinforcedBox;

        bool interacted;

        public delegate void SwitchFlipped();
        public event SwitchFlipped switchFlipped;

        public override void Interact() {
            if (interacted) {
                DialogueSystem.Instance.AddNewDialogue(emptyDialogue, "Yenen");
            }
            else
                aSource.PlayOneShot(reinforcedBox);
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