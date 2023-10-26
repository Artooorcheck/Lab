using Lab.Entity;

namespace Lab.Actions
{
    public interface IFightAction
    {
        void StartFight(IAttackable attackable);
        void StopFight(IAttackable attackable);
    }
}
