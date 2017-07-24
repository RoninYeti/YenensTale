using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YenensTale {
    public class lightSwitch2 : MonoBehaviour {

        private Light light2;
        static bool toggleLight2 = false;

        void Start() {
            light2 = GetComponent<Light>();
            light2.enabled = false;
        }

        void Update() {
            light2.enabled = (toggleLight2);
        }

        public static bool ToggleLight2 {
            get
            {
                return toggleLight2;
            }
            set
            {
                toggleLight2 = value;
            }
        }
    }
}