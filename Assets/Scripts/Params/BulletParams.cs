using UnityEngine;

namespace Lab.Params
{
    [System.Serializable]
    class BulletParams
    {
        public Vector3 Target { get; set; }
        [field: SerializeField] public float FlightTime { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
    }
}
