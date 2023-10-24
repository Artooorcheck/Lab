using UnityEngine;

namespace Lab.Entity
{
    public interface IMovable : IPosable, IResponsable
    {
        void Move(Vector3 point);
    }
}
