using Lab.Entity;
using System.Collections;
using UnityEngine;

namespace Lab.Actions
{
    class MeleeAttack
    {
        private float _cooldown;
        private float _damage;


        private bool _onAttack;

        public MeleeAttack(float damage, float cooldown)
        {
            _damage = damage;
            _cooldown = cooldown;
        }

        public void Start(MonoBehaviour attacker, IAttackable attackable)
        {
            _onAttack = true;
            attacker.StartCoroutine(Fight(attackable));
        }

        public void Stop()
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
