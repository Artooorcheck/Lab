namespace Lab.Controllers
{
    interface IController
    {
        void Init();
        void Remove<T>(T entity);
    }
}
