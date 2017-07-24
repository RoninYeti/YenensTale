using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YenensTale {
    public class lightSwitch3 : MonoBehaviour {

        private Light light3;
        static bool toggleLight3 = false;

        void Start() {
            light3 = GetComponent<Light>();
            light3.enabled = false;
        }

        void Update() {
            light3.enabled = (toggleLight3);
        }

        public static bool ToggleLight3 {
            get
            {
                return toggleLight3;
            }
            set
            {
                toggleLight3 = value;
            }
        }
    }
}