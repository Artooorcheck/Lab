using UnityEngine.AI;
using UnityEngine;
using Lab.Entity;
using System;

namespace Lab.AI
{
    [RequireComponent(typeof(NavMeshAgent))]
    class Navigator : MonoBehaviour
    {
        public bool IsStopped { get; private set; }

        private NavMeshAgent _navMeshAgent;

        public event Action OnStopped;


        public void Init()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void SetDestination(Vector3 point)
        {
            _navMeshAgent.isStopped = false;
            _navMeshAgent.SetDestination(point);
            IsStopped = false;
        }

        public void Stop()
        {
            _navMeshAgent.isStopped = true;
        }

        public void FrameUpdate(float deltaTime)
        {
            if (_navMeshAgent.hasPath && !IsStopped)
            {
                IsStopped = true;
                OnStopped?.Invoke();
            }
        }
    }
}
