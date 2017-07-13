using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

namespace YenensTale {
    public class KayCrystal : ActionItem {

        public AudioSource aSource;
        public AudioClip fadingTransition;

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

        public override void Interact() {
            DialogueSystem.Instance.AddNewDialogue(dialogue.dialogueSeries[Mathf.Min(interactions++, dialogue.dialogueSeries.Length - 1)].dialogue, "Yenen");
            if (interactions >= 1) {
                StartCoroutine(DelayFade());
            }
        }

        IEnumerator DelayFade() {
            yield return new WaitForSeconds(4);
            Scene currentScene = SceneManager.GetActiveScene();
            //Need to mute "The Fog" from Camera Audio Source
            aSource.PlayOneShot(fadingTransition);
            SceneManager.LoadScene("Par'N Terrain/Par'n Kay Crystal (Crossroad)", LoadSceneMode.Additive);
            yield return new WaitForSeconds(15);
            //Need to bring Player back to original scene
            //Need to play "Fade In" audio clip
            //Need to unmute "The Fog" from Camera Audio Source
        }
    }
}