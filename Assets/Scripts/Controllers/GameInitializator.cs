using Lab.Entity;
using System.Collections.Generic;
using UnityEngine;

class GameInitializator : MonoBehaviour
{

    private IEnumerable<IController> _controllers;

    public void Awake()
    {
        var initializables = GetComponentsInChildren<IInitializable>();
        foreach (var initializable in initializables)
        {
            initializable.Init();
        }

        _controllers = GetComponents<IController>();
        foreach (var controller in _controllers)
        {
            controller.Init();
        }

        var entityDestroyer = new EntityDestroyer();
        entityDestroyer.OnDestroyed += DestroyEntity;
    }


    private void DestroyEntity(Entity entity)
    {
        foreach (var controller in _controllers)
        {
            controller.Remove(entity);
        }
    }
}
