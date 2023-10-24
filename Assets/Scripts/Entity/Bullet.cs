using Lab.Params;
using System.Collections;
using UnityEngine;

namespace Lab.Entity
{
    class Bullet : MonoBehaviour
    {
        private BulletParams _params;
        private Transform _transform;

        public void Init(string name, BulletParams bulletParams)
        {
            this.name = name;
            _params = bulletParams;
            _transform = transform;
            StartCoroutine(MoveAsync());
        }

        private IEnumerator MoveAsync()
        {
            Vector3 startPosition = _transform.position;
            for(float time = 0; time < 1; time+=Time.deltaTime)
            {
                _transform.position = Vector3.Lerp(startPosition, _params.Target, time);
                yield return null;
            }

            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.name !=  name 
                && other.TryGetComponent(out Entity entity))
            {
                entity.Damage(_params.Damage);
                Destroy(gameObject);
            }
        }
    }
}
