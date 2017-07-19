using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace YenensTale {
    public class DialogueSystem : MonoBehaviour {
        
        public static DialogueSystem Instance { get; set; }
        public GameObject dialoguePanel;
        public string npcName;
        public List<string> dialogueLines = new List<string>();

        public AudioSource aSource;
        public AudioClip nextBox;

        Button continueButton;
        Text dialogueText, nameText;
        int dialogueIndex;

        void Awake() {
            continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
            dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
            nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();
            continueButton.onClick.AddListener(delegate { ContinueDialogue(); });
            dialoguePanel.SetActive(false);

            if (Instance != null && Instance != this) {
                Destroy(gameObject);
            }

            else {
                Instance = this;
            }
        }

        public void AddNewDialogue(string[] lines, string npcName) {
            dialogueIndex = 0;
            dialogueLines = new List<string>();
            foreach (string line in lines) {
                dialogueLines.Add(line);
            }

            this.npcName = npcName;

            CreateDialogue();
        }

        public void CreateDialogue() {
            dialogueText.text = dialogueLines[dialogueIndex];
            nameText.text = npcName;
            dialoguePanel.SetActive(true);
        }

        public void ContinueDialogue() {
            if (dialogueIndex < dialogueLines.Count - 1) {
                aSource.PlayOneShot(nextBox);
                dialogueIndex++;
                dialogueText.text = dialogueLines[dialogueIndex];
            }

            else {
                aSource.PlayOneShot(nextBox);
                dialoguePanel.SetActive(false);
            }
        }
    }
}