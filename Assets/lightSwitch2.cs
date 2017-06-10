using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YenensTale
{
    public class lightSwitch2 : MonoBehaviour
    {

        private Light light2;
        static bool toggleLight2 = false;

        // Use this for initialization
        void Start()
        {
            light2 = GetComponent<Light>();
            light2.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            light2.enabled = (toggleLight2);
        }

        /*public void toggleLight2()
        {
            light2.enabled = true;
        }
        */

        public static bool ToggleLight2
        {
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