using UnityEngine;

namespace Lab.Params
{
    [CreateAssetMenu(fileName = "EntityParams", menuName = "Params/EntityParams")]
    public class EntityParams : ScriptableObject
    {
        [field: SerializeField] public float HP { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float FlickTime { get; private set; }
        [field: SerializeField] public Color FlickColor { get; private set; }
        [field: SerializeField] public Color DefaultColor { get; private set; }
    }
}
