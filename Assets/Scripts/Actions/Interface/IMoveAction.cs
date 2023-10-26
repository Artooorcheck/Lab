using Lab.Entity;

namespace Lab.Actions
{
    public interface IMoveAction
    {
        void StartMove(IPosable target);
        void StopMove();
        void ResetTarget();
        void ContinueMove();
    }
}
