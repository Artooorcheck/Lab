using Lab.Entity;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lab.Controllers
{
    class AttackerController : MonoBehaviour, IController, IUpdate
    {
        private List<IAttackable> _attackables;
        
        private List<IAttacker> _attackers;

        public void Init()
        {
            _attackers = GetComponentsInChildren<IAttacker>().ToList();
            _attackables = GetComponentsInChildren<IAttackable>().ToList();
            foreach (var attacker in _attackers)
            {
                attacker.OnFinishTask += (resp) => _attackers.Add((IAttacker)resp);
                attacker.OnStartTask += (resp) => _attackers.Remove((IAttacker)resp);
            }
        }

        public void Remove<T>(T entity)
        {
            _attackables.RemoveAll(a => a.Equals(entity));
            _attackers.RemoveAll(a => a.Equals(entity));
        }

        public void FrameUpdate(float deltaTime)
        {
            if (_attackables.Count <= 1)
                return;

            for(int i=0; i< _attackers.Count; i++)
            {
                _attackers[i].SetTarget(GetRandomEnemy(_attackers[i]));
            }
        }

        private IAttackable GetRandomEnemy(IAttacker attacker)
        {
            return _attackables.Where(a => !a.Equals(attacker)).ElementAt(Random.Range(0, _attackables.Count - 1));
        }
    }
}
