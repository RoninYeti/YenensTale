using UnityEngine;
using System.Collections.Generic;

namespace YenensTale {
    public class CharacterStats : MonoBehaviour, IReceiveDamage {

        public List<BaseStat> stats = new List<BaseStat>();

        void Start() {
            stats.Add(new BaseStat(4, "Power", "Your power level."));
            stats.Add(new BaseStat(2, "Vitality", "Your vitality level."));
        }

        public void AddStatBonus(List<BaseStat> statBonuses) {
            foreach (BaseStat statBonus in statBonuses) {
                stats.Find(x => x.StatName == statBonus.StatName).AddStatBonus(new StatBonus(statBonus.BaseValue));
            }
        }

        public void RemoveStatBonus(List<BaseStat> statBonuses) {
            foreach (BaseStat statBonus in statBonuses) {
                stats.Find(x => x.StatName == statBonus.StatName).AddStatBonus(new StatBonus(statBonus.BaseValue));
            }
        }

        public void ReceiveDamage(Vector3 direction, float damage, GameObject source) {
            transform.position -= direction;
        }
    }
}