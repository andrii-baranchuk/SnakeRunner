namespace Infrastructure.Bootstrap
{
    using Economics;
    using Economics.Wallet;
    using Input;
    using ServiceLocator;
    using SnakeRunner.Gameplay.Camera;
    using SnakeRunner.Gameplay.Color;
    using Tools;
    using UI;
    using UnityEngine;

    public class Game
    {
        private readonly AllServices services;
        public Game(ICoroutineRunner coroutineRunner)
        {
            services = AllServices.Container;
            
            services.RegisterSingle<IInputProvider>(new InputProvider());
            services.RegisterSingle(ColorSettings.Load());
            services.RegisterSingle<ICurrencyWallet<GemsCurrency>>(new CurrencyWallet<GemsCurrency>());
            services.RegisterSingle<IUIBuilder>(new UIBuilder());
            CameraService cameraService = Object.FindObjectOfType<CameraService>();
            services.RegisterSingle(cameraService);
        }
    }
}