using System.Collections;
using UnityEngine;

namespace Lab.Effects
{
    [RequireComponent(typeof(Renderer))]
    class Flicker: MonoBehaviour
    {
        private Renderer _renderer;

        private Color _defaultColor;
        private Color _flickColor;

        private float _flickTime;

        public void Init(Color defaultColor, Color flickColor, float flickTime)
        {
            _flickTime = flickTime;
            _defaultColor = defaultColor;
            _flickColor = flickColor;
            _renderer = GetComponent<Renderer>();
        }

        public void Flick()
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
