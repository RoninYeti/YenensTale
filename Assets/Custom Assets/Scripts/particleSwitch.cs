﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YenensTale {
    public class particleSwitch : MonoBehaviour {

        static bool toggleParticle;

        void Start() {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
        }

        void Update() {
            if (toggleParticle == true) {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(2).gameObject.SetActive(true);
            }

            else {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
            }
        }

        public static bool ToggleParticle {
            get
            {
                return toggleParticle;
            }
            set
            {
                toggleParticle = value;
            }
        }
    }
}