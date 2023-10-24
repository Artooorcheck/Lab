namespace Lab.Entity
{
    public interface IAttacker : IPosable, IResponsable
    {
        void SetTarget(IAttackable enemy);
    }
}
