using Lab.Exceptions;
using Lab.Triggers;
using System.Linq;
using UnityEngine;


namespace Lab.Entity
{
    [RequireComponent(typeof(ITrigger<Entity>))]
    public class Shooter : Entity, IAttacker, IUpdate, IInitializable
    {
        [SerializeField] private float _cooldown;
        [SerializeField] private float _speed;
        [SerializeField] private Bullet _bulletPrefab;

        private ITrigger<Entity> _trigger;

        public override void Init()
        {
            base.Init();
            _trigger = (ITrigger<Entity>)GetComponents<MonoBehaviour>()
                .First(a=>a is ITrigger<Entity>);
        }


        public void SetTarget(IAttackable target)
        {
            if (this.Equals(target))
                throw new SelfAttackException();

            StartTask();
            Instantiate(_bulletPrefab, transform.position, Quaternion.identity)
                .Init(name, target.Position);
            Invoke(nameof(FinishTask), _cooldown);
        }

        private void Dodge(Vector3 attacker, float speed)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.position - attacker, speed);
        }

        public void FrameUpdate(float deltaTime)
        {
            if(_trigger.Entities.Count > 0)
            {
                var entity = _trigger.Entities.FirstOrDefault(a => a != null && a.isActiveAndEnabled);
                if (entity != null)
                {
                    Dodge(entity.Position, deltaTime * _speed);
                }
            }
        }
    }
}