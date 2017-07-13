using UnityEngine;
using System.Collections;

namespace YenensTale {
    public class SignPost : ActionItem {

        public string[] dialogue;
        public AudioSource aSource;
        public AudioClip signPostStart;

        public override void Interact() {
            aSource.PlayOneShot(signPostStart);
            DialogueSystem.Instance.AddNewDialogue(dialogue, "Yenen");
        }
    }
}