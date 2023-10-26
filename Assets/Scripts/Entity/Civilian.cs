using Lab.AI;
using UnityEngine;


namespace Lab.Entity
{
    [RequireComponent(typeof(INavigator))]
    public class Civilian : Entity, IMovable
    {

        private INavigator _navigator;

        public override void Init()
        {
            base.Init();
            _navigator = GetComponent<INavigator>();
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
        }

        public void Complete()
        {
            _navigator.OnStopped -= Complete;
            FinishTask();
        }
    }
}
