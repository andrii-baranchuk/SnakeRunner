namespace Infrastructure.Bootstrap
{
    using Tools;
    using UnityEngine;

    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game game;

        private void Awake()
        {
            game = new Game(this);
            
            DontDestroyOnLoad(this);
        }
    }
}