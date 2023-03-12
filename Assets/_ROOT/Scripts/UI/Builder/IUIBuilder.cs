namespace UI
{
    using Infrastructure.ServiceLocator;

    public interface IUIBuilder : IService
    {
        T CreateWindow<T>() where T : Window;
    }
}