using UnityEngine;

namespace Lab.Params
{
    [CreateAssetMenu(fileName = "MeleeFighterParams", menuName = "Params/MeleeFighterParams")]
    public class MeleeFighterParams : EntityParams
    {
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float Cooldown { get; private set; }
    }
}
