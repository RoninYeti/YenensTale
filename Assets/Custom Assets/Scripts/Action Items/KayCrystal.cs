using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

namespace YenensTale
{
    public class KayCrystal : ActionItem
    {

        [Serializable]
        public struct DialogueSequence
        {
            public DialogueSeries[] dialogueSeries;
        }

        [Serializable]
        public struct DialogueSeries
        {
            public string[] dialogue;
        }

        [SerializeField]
        DialogueSequence dialogue;
        int interactions = 0;

        public override void Interact()
        {
            DialogueSystem.Instance.AddNewDialogue(dialogue.dialogueSeries[Mathf.Min(interactions++, dialogue.dialogueSeries.Length - 1)].dialogue, "Yenen");
            if (interactions >= 1)
            {
                KayCrystalManager.Instance.DoTransition();
            }
        }
    }
}