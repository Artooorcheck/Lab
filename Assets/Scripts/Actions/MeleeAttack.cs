using Lab.Entity;
using System.Collections;
using UnityEngine;

namespace Lab.Actions
{
    class MeleeAttack: MonoBehaviour, IFightAction
    {
        [SerializeField] private float _cooldown;
        [SerializeField] private float _damage;

        private bool _onAttack;

        public MeleeAttack(MonoBehaviour attacker, float damage, float cooldown)
        {
            _damage = damage;
            _cooldown = cooldown;
        }

        public void StartFight(IAttackable attackable)
        {
            _onAttack = true;
            StartCoroutine(Fight(attackable));
        }

        public void StopFight(IAttackable attackable)
        {
            _onAttack = false;
        }

        private IEnumerator Fight(IAttackable attackable)
        {
            var cooldown = new WaitForSeconds(_cooldown);
            while(_onAttack)
            {
                attackable.Damage(_damage);
                yield return cooldown;
            }
        }
    }
}
