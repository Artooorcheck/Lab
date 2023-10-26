using System.Collections;
using UnityEngine;

namespace Lab.Entity
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _flightTime;
        [SerializeField] private float _damage;


        public virtual void Init(string name, Vector3 target)
        {
            this.name = name;
            StartCoroutine(MoveAsync(target));
        }

        private IEnumerator MoveAsync(Vector3 target)
        {
            Vector3 startPosition = transform.position;
            for(float time = 0; time < 1; time+=Time.deltaTime/_flightTime)
            {
                transform.position = Vector3.Lerp(startPosition, target, time);
                yield return null;
            }

            Destroy(gameObject);
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if(other.name !=  name 
                && other.TryGetComponent(out Entity entity))
            {
                entity.Damage(_damage);
                Destroy(gameObject);
            }
        }
    }
}
