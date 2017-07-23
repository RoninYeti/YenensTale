using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YenensTale {
    public interface IReceiveDamage {
        void ReceiveDamage(Vector3 direction, float damage, GameObject source);
    }
}