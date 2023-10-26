using UnityEngine;
using Lab.Triggers;
using Lab.Actions;
using Lab.Exceptions;

namespace Lab.Entity
{
    [RequireComponent(typeof(IMoveAction), typeof(AttackableTrigger), typeof(IFightAction))]
    public class MeleeFighter : Entity, IAttacker
    {
        private AttackableTrigger _trigger;
        private IMoveAction _moveAction;
        private IAttackable _enemy;
        private IFightAction _attack;

        public override void Init()
        {
            base.Init();
            _moveAction = GetComponent<IMoveAction>();
            _trigger = GetComponent<AttackableTrigger>();
            _trigger.OnEnter += EnemyOnTrigger;
            _trigger.OnExit += EnemyLeftTrigger;
            _attack = GetComponent<IFightAction>();
        }

        public void SetTarget(IAttackable enemy)
        {
            if(this.Equals(enemy))
                throw new SelfAttackException();

            StartTask();
            _enemy = enemy;
            enemy.OnDestroy += FinishTask;
            _moveAction.StartMove(enemy);
        }

        private void FinishTask(IDestroyeble destroyeble)
        {
            _moveAction.ResetTarget();
            FinishTask();
        }

        public void EnemyOnTrigger(IAttackable attackable)
        {
            if (attackable != _enemy)
                return;

            _moveAction.StopMove();
            _attack.StartFight(attackable);
        }

        public void EnemyLeftTrigger(IAttackable attackable)
        {
            if (attackable != _enemy)
                return;

            _attack.StopFight(attackable);
            _moveAction.ContinueMove();
        }

        protected override void Destroy()
        {
            CancelTarget();
            base.Destroy();
        }

        public void CancelTarget()
        {
            if (_enemy == null)
                return;

            _enemy.OnDestroy -= FinishTask;
            _moveAction.ResetTarget();
        }
    }
}