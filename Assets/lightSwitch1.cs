using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YenensTale
{
    public class lightSwitch1 : MonoBehaviour
    {

        private Light light1;
        static bool toggleLight1 = false;
        // Use this for initialization
        void Start()
        {
            light1 = GetComponent<Light>();
            light1.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            light1.enabled = (toggleLight1);
        }

        /*public void toggleLight1()
        {
            light1.enabled = true;
        }
        */

        public static bool ToggleLight1
        {
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