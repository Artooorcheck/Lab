using UnityEngine;
using Lab.AI;
using Lab.Params;
using Lab.Effects;
using System.Collections;
using Lab.Triggers;
using Lab.Actions;
using Lab.Exceptions;

namespace Lab.Entity
{
    [RequireComponent(typeof(Navigator), typeof(AttackableTrigger), typeof(Flicker))]
    class MeleeFighter : Entity, IAttacker, IUpdate
    {
        private Navigator _navigator;
        private MeleeFighterParams _params;
        private Flicker _flicker;
        private IAttackable _enemy;
        private AttackableTrigger _trigger;
        private MeleeAttack _attack;

        public void Init(MeleeFighterParams fighterParams)
        {
            base.Init(fighterParams);
            _params = fighterParams;
            _navigator = GetComponent<Navigator>();
            _navigator.Init();
            _trigger = GetComponent<AttackableTrigger>();
            _trigger.OnEnter += EnemyOnTrigger;
            _trigger.OnExit += EnemyLeftTrigger;
            _flicker = GetComponent<Flicker>();
            _flicker.Init(_params.DefaultColor, _params.FlickColor, _params.FlickTime);
            OnDamage += (val) => _flicker.Flick();
            _attack = new MeleeAttack(fighterParams.Damage, fighterParams.Cooldown);
        }

        public void SetTarget(IAttackable enemy)
        {
            if(this.Equals(enemy))
                throw new SelfAttackException();

            StartTask();
            _enemy = enemy;
            enemy.OnDestroy += FinishTask;
            _navigator.OnStopped += Move;

            Move();
        }

        private void FinishTask(IAttackable attackable)
        {
            _enemy = null;
            FinishTask();
        }

        private void Move()
        {
            if (_enemy != null)
            {
                _navigator.SetDestination(_enemy.Position);
            }
        }

        public void EnemyOnTrigger(IAttackable attackable)
        {
            if (attackable != _enemy)
                return;

            _navigator.OnStopped -= Move;
            _navigator.Stop();
            _attack.Start(this, attackable);
        }

        public void EnemyLeftTrigger(IAttackable attackable)
        {
            if (attackable != _enemy)
                return;

            _attack.Stop();
            _navigator.OnStopped += Move;
            Move();
        }

        protected override void Destroy()
        {
            CancelTarget();
            base.Destroy();
        }

        public void FrameUpdate(float deltaTime)
        {
            _navigator.FrameUpdate(deltaTime);
        }

        public void CancelTarget()
        {
            if (_enemy == null)
                return;

            _enemy.OnDestroy -= FinishTask;
            _navigator.Stop();
            _enemy = null;
        }
    }
}