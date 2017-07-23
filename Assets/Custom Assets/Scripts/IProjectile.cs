using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectile {
    Vector3 Direction { get; set; }
    float Range { get; set; }
    int Damage { get; set; }
}
