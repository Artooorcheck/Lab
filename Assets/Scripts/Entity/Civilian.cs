using Lab.AI;
using Lab.Effects;
using Lab.Params;
using UnityEngine;


namespace Lab.Entity
{
    [RequireComponent(typeof(Navigator), typeof(Flicker))]
    class Civilian : Entity, IMovable, IUpdate
    {

        private Navigator _navigator;
        private Flicker _flicker;
        private EntityParams _params;

        public override void Init(EntityParams entityParams)
        {
            base.Init(entityParams);
            _params = entityParams;
            _navigator = GetComponent<Navigator>();
            _navigator.Init();
            _flicker = GetComponent<Flicker>();
            _flicker.Init(_params.DefaultColor, _params.FlickColor, _params.FlickTime);
            OnDamage += (val) => _flicker.Flick();
        }

        public void Move(Vector3 target)
        {
            StartTask();
            _navigator.SetDestination(target);

            _navigator.OnStopped += Complete;

        }

        public override void Damage(float value)
        {
            if (IsDestroyed)
                return;

            base.Damage(value);
            _flicker.Flick();
        }

        public void Complete()
        {
            _navigator.OnStopped -= Complete;
            FinishTask();
        }

        public void FrameUpdate(float deltaTime)
        {
            _navigator.FrameUpdate(deltaTime);
        }
    }
}
