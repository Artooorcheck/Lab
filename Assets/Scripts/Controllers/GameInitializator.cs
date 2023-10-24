using Lab.Entity;
using Lab.Params;
using System.Collections.Generic;
using UnityEngine;

namespace Lab.Controllers
{
    class GameInitializator : MonoBehaviour
    {
        [SerializeField] private EntityParams _civilianParams;
        [SerializeField] private MeleeFighterParams _meleeFighterParams;
        [SerializeField] private ShooterParams _shooterParams;

        private IEnumerable<IController> _controllers;

        public void Awake()
        {
            var civilians = GetComponentsInChildren<Civilian>();
            foreach(var cicilian in civilians)
            {
                cicilian.Init(_civilianParams);
            }

            var meleeFighters = GetComponentsInChildren<MeleeFighter>();
            foreach (var meleeFighter in meleeFighters)
            {
                meleeFighter.Init(_meleeFighterParams);
            }

            var shooters = GetComponentsInChildren<Shooter>();
            foreach (var shooter in shooters)
            {
                shooter.Init(_shooterParams);
            }

            _controllers = GetComponents<IController>();
            foreach (var controller in _controllers)
            {
                controller.Init();
            }

            var entityDestroyer = new EntityDestroyer();
            entityDestroyer.OnDestroyed += DestroyEntity;
        }


        private void DestroyEntity(Entity.Entity entity)
        {
            foreach (var controller in _controllers)
            {
                controller.Remove(entity);
            }
        }
    }
}
