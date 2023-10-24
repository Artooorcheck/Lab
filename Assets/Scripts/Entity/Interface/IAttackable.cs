

using System;

namespace Lab.Entity
{
    public interface IAttackable : IPosable
    {
        float HP { get; }

        event Action<IAttackable> OnDestroy;
        event Action<float> OnDamage;

        void Damage(float value);
    }
}
