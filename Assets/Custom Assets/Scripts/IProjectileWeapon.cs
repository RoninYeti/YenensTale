using UnityEngine;

namespace YenensTale {
    public interface IProjectileWeapon {

        Transform ProjectileSpawn { get; set; }
        void CastProjectile();
    }
}