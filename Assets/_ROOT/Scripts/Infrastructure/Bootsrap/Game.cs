namespace Infrastructure.Bootstrap
{
    using Input;
    using ServiceLocator;
    using SnakeRunner.Gameplay.Color;
    using Tools;

    public class Game
    {
        private readonly AllServices services;
        public Game(ICoroutineRunner coroutineRunner)
        {
            services = AllServices.Container;
            
            services.RegisterSingle<IInputProvider>(new InputProvider());
            services.RegisterSingle<ColorSettings>(ColorSettings.Load());
        }
    }
}