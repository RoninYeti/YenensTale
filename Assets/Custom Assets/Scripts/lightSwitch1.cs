using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YenensTale {
    public class lightSwitch1 : MonoBehaviour {

        private Light light1;
        static bool toggleLight1 = false;

        void Start() {
            light1 = GetComponent<Light>();
            light1.enabled = false;
        }

        void Update() {
            light1.enabled = (toggleLight1);
        }

        public static bool ToggleLight1 {
            get
            {
                return toggleLight1;
            }
            set
            {
                toggleLight1 = value;
            }
        }
    }
}