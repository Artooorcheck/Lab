using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lab.Triggers
{
    public class Trigger<T> : MonoBehaviour, ITrigger<T>
    {
        private List<T> _entities = new List<T>();

        public IReadOnlyList<T> Entities => _entities;

        public event Action<T> OnEnter;

        public event Action<T> OnExit;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out T entity))
            {
                _entities.Add(entity);
                OnEnter?.Invoke(entity);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out T entity))
            {
                _entities.Remove(entity);
                OnExit?.Invoke(entity);
            }
        }
    }
}
