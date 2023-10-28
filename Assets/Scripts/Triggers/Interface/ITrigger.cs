using System;
using System.Collections.Generic;

namespace Lab.Triggers
{
    public interface ITrigger<out T>
    {
        public IReadOnlyList<T> Entities { get; }

        public event Action<T> OnEnter;

        public event Action<T> OnExit;

    }
}
