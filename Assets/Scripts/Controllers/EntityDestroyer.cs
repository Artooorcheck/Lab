using System;
using UnityEngine;

namespace Lab.Controllers
{
    class EntityDestroyer
    {
        public event Action<Entity.Entity> OnDestroyed;

        public EntityDestroyer()
        {
            var entities = UnityEngine.Object.FindObjectsOfType<Entity.Entity>();
            foreach(var entity in entities)
            {
                entity.OnDestroy += (attackable) => Destroy(entity);
            }
        }

        private void Destroy(Entity.Entity entity)
        {
            OnDestroyed?.Invoke(entity);

            UnityEngine.Object.Destroy(entity.gameObject);
        }
    }
}
