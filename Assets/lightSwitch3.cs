using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YenensTale
{
    public class lightSwitch3 : MonoBehaviour
    {

        private Light light3;
        static bool toggleLight3 = false;

        // Use this for initialization
        void Start()
        {
            light3 = GetComponent<Light>();
            light3.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            light3.enabled = (toggleLight3);
        }

        /*public void toggleLight3()
        {
            light3.enabled = true;
        } */

        public static bool ToggleLight3
        {
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