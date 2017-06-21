﻿using UnityEngine;
using System.Collections;

namespace YenensTale {
    public class NPC : Interactable {

        public string[] dialogue;
        public string name;

        public override void Interact() {
            DialogueSystem.Instance.AddNewDialogue(dialogue, name);
            //Debug.Log("Interacting with NPC!");
        }
    }
}