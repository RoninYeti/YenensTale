using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

namespace YenensTale {
    public class KayCrystal : ActionItem {

        public object aSource;
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
            //print(Time.time);
            yield return new WaitForSeconds(4);
            //print(Time.time);
            Scene currentScene = SceneManager.GetActiveScene();
            //aSource.PlayOneShot(fadingTransition);                   Fix this sound!!
            SceneManager.LoadScene("Par'N Terrain/Par'n Kay Crystal (Crossroad)", LoadSceneMode.Additive);
            yield return new WaitForSeconds(15);
            //SceneManager.LoadScene("Par'N Terrain/Par'n Terrain", LoadSceneMode.Additive);                 Fix this line!!
        }
    }
}