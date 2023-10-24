using Lab.Effects;
using Lab.Exceptions;
using Lab.Params;
using Lab.Triggers;
using UnityEngine;



namespace Lab.Entity
{
    [RequireComponent(typeof(MeleeFighterTrigger), typeof(Flicker))]
    class Shooter : Entity, IAttacker, IUpdate
    {

        private ShooterParams _params;
        private Flicker _flicker;
        private MeleeFighterTrigger _trigger;

        public void Init(ShooterParams shooterParams)
        {
            base.Init(shooterParams);
            _params = shooterParams;
            _flicker = GetComponent<Flicker>();
            _flicker.Init(_params.DefaultColor, _params.FlickColor, _params.FlickTime);
            OnDamage += (val) => _flicker.Flick();
            _trigger = GetComponent<MeleeFighterTrigger>();
        }


        public void SetTarget(IAttackable target)
        {
            if (this.Equals(target))
                throw new SelfAttackException();

            StartTask();
            var bp = _params.BulletParams;
            bp.Target = target.Position;
            Instantiate(_params.BulletPrefab, transform.position, Quaternion.identity)
                .Init(name, bp);
            Invoke(nameof(FinishTask), _params.Cooldown);
        }

        private void Dodge(Vector3 attacker, float speed)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.position - attacker, speed);
        }

        public void FrameUpdate(float deltaTime)
        {
            if(_trigger.Entities.Count > 0)
            {
                Dodge(_trigger.Entities[0].Position, deltaTime * _params.Speed);
            }
        }
    }
}