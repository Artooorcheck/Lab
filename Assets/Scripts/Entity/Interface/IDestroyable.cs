using System;

namespace Lab.Entity
{
    public interface IDestroyeble
    {
        event Action<IDestroyeble> OnDestroy;
    }
}
