using System.Collections.Generic;

namespace YenensTale {
    public interface IWeapon {

        List<BaseStat> Stats { get; set; }
        void PerformAttack();
        void PerformSpecialAttack();
    }
}