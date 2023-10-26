using UnityEngine.AI;
using UnityEngine;
using Lab.Entity;
using System;

namespace Lab.AI
{
    public interface INavigator
    {
        public bool IsStopped { get; }

        public event Action OnStopped;

        public void SetDestination(Vector3 point);

        public void Stop();
    }
}
