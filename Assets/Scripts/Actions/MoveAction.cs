using Lab.AI;
using Lab.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab.Actions
{
    [RequireComponent(typeof(INavigator))]
    class MoveAction : MonoBehaviour, IMoveAction, IInitializable
    {
        private INavigator _navigator;

        private IPosable _target;

        public void Init()
        {
            _navigator = GetComponent<INavigator>();
        }

        public void StartMove(IPosable target)
        {
            _target = target;
            _navigator.OnStopped += Move;

            Move();
        }

        public void StopMove()
        {
            _navigator.Stop();
        }

        private void Move()
        {
            if (_target != null)
            {
                _navigator.SetDestination(_target.Position);
            }
        }

        public void ResetTarget()
        {
            _navigator.OnStopped -= Move;
            _target = null;
        }

        public void ContinueMove()
        {
            Move();
        }
    }
}
