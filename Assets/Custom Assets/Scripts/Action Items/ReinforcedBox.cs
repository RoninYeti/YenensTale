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
            print("A");
            if (interacted)
            {
                DialogueSystem.Instance.AddNewDialogue(emptyDialogue, "Yenen");
            }
            else
            {
                aSource.PlayOneShot(reinforcedBox);
                DialogueSystem.Instance.AddNewDialogue(dialogue, "Yenen");
                //Call event that tells subscribers this switch has been flipped
                if (switchFlipped != null)
                {
                    switchFlipped();
                }
            }
            interacted = true;

            

            //print(lightPost.BoxSwitch);
            //activate.equipRecharge();
        }
    }
}