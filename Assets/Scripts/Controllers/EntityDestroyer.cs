using Lab.Entity;
using System;
using UnityEngine;

class EntityDestroyer
{
    public event Action<Entity> OnDestroyed;

    public EntityDestroyer()
    {
        var entities = UnityEngine.Object.FindObjectsOfType<Entity>();
        foreach (var entity in entities)
        {
            entity.OnDestroy += (attackable) => Destroy(entity);
        }
    }

    private void Destroy(Entity entity)
    {
        OnDestroyed?.Invoke(entity);

        UnityEngine.Object.Destroy(entity.gameObject);
    }
}
