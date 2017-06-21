using System.Collections;
using UnityEngine;

namespace YenensTale {
    public class StatBonus {

        public int BonusValue { get; set; }

        public StatBonus(int bonusValue) {
            this.BonusValue = bonusValue;
            //Debug.Log("New stat bonus initiated.");
        }
    }
}