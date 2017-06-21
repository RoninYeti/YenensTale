using UnityEngine;
using System.Collections;

namespace YenensTale {
    public class SignPost : ActionItem {

        public string[] dialogue;
        public object aSource;
        public AudioClip signPostStart;

        public override void Interact() {
            //aSource.PlayOneShot(signPostStart);                          Fix this sound!!
            DialogueSystem.Instance.AddNewDialogue(dialogue, "Yenen");
        }
    }
}