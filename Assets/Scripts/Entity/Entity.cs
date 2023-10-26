
using Lab.Effects;
using Lab.Exceptions;
using System;
using UnityEngine;


namespace Lab.Entity
{
    public class Entity : MonoBehaviour, IAttackable, IResponsable, IInitializable
    {
        [field:SerializeField] public float HP { get; private set; }
        public bool IsFree { get; private set; }
        public bool IsDestroyed { get; private set; }

        public Vector3 Position => transform.position;

        public event Action<IDestroyeble> OnDestroy;

        public event Action<float> OnDamage;

        public event Action<IResponsable> OnStartTask;
        public event Action<IResponsable> OnFinishTask;

        public virtual void Init()
        {
            IsFree = true;
            var effects = GetComponentsInChildren<IEffect>();
            foreach(var effect  in effects)
            {
                OnDamage += (val) => effect.Play();
            }
        }

        public virtual void Damage(float value)
        {
            if(IsDestroyed)
                return;

            HP -= value;
            OnDamage?.Invoke(value);
            if (HP <= 0)
            {
                Destroy();
            }
        }

        protected virtual void Destroy()
        {
            IsDestroyed = true;
            OnDestroy?.Invoke(this);
        }

        protected void StartTask()
        {
            if (!IsFree)
                throw new HasTaskException();

            IsFree = false;
            OnStartTask?.Invoke(this);
        }

        protected void FinishTask()
        {
            IsFree = true;
            OnFinishTask?.Invoke(this);
        }
    }
}
