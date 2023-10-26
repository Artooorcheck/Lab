using Lab.Entity;
using System.Collections;
using UnityEngine;

namespace Lab.Effects
{
    [RequireComponent(typeof(Renderer))]
    class Flicker: MonoBehaviour, IEffect, IInitializable
    {
        private Renderer _renderer;

        [SerializeField] private Color _defaultColor;
        [SerializeField] private Color _flickColor;

        [SerializeField] private float _flickTime;

        public void Init()
        {
            _renderer = GetComponent<Renderer>();
        }

        public void Play()
        {
            var material = _renderer.material;
            material.color = _flickColor;
            _renderer.material = material;
            StartCoroutine(SetDefaultColor());
        }

        private IEnumerator SetDefaultColor()
        {
            yield return new WaitForSeconds(_flickTime);
            var material = _renderer.material;
            material.color = _defaultColor;
            _renderer.material = material;
        }
    }
}
