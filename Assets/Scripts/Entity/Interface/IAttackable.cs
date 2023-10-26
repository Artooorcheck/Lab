

using System;

namespace Lab.Entity
{
    public interface IAttackable : IPosable, IDestroyeble
    {
        float HP { get; }

        event Action<float> OnDamage;

        void Damage(float value);
    }
}
