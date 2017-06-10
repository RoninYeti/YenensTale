using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

namespace YenensTale
{
    public class LightPost : ActionItem
    {
        public string[] dialogue;
        public string[] onDialogue;
        bool boxSwitch = false;
        [SerializeField]
        ReinforcedBox box;
        public GlobalFog fogRef;
        public float FogTransSpeed = .33f;
        public float heightLimit = 5f;
        public float timeTransSpeed = .33f;

        void Start()
        {

            box.switchFlipped += Box_switchFlipped;
            //StartCoroutine(DelayFade());
        }

        private void Box_switchFlipped()
        {
            boxSwitch = true;
        }

        public override void Interact()
        {
            if (boxSwitch)
                DialogueSystem.Instance.AddNewDialogue(onDialogue, "Yenen");
            else
                DialogueSystem.Instance.AddNewDialogue(dialogue, "Yenen");
            //Debug.Log("Interacting with Light Post!");

            if (boxSwitch == true)
            {

                particleSwitch.ToggleParticle = true;
                lightSwitch1.ToggleLight1 = true;
                lightSwitch2.ToggleLight2 = true;
                lightSwitch3.ToggleLight3 = true;
                StartCoroutine(lowerFog());
                //call function to enable lights and particle objects here
            }

        }

        public bool BoxSwitch
        {
            get
            {
                return boxSwitch;
            }
            set
            {
                boxSwitch = value;
            }
        }

        IEnumerator lowerFog()
        {
            float i = fogRef.height;
            while (i > heightLimit)
            {
                yield return new WaitForSeconds(timeTransSpeed);
                i -= FogTransSpeed;
                fogRef.height = i;
            }
        }
    }
}