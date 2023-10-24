using Lab.Entity;
using UnityEngine;

namespace Lab.Params
{
    [CreateAssetMenu(fileName = "ShooterParams", menuName = "Params/ShooterParams")]
    class ShooterParams : EntityParams
    {
        [field: SerializeField] public float Cooldown { get; private set; }
        [field: SerializeField] public Bullet BulletPrefab { get; private set; }
        [field: SerializeField] public BulletParams BulletParams { get; private set; }
    }
}
