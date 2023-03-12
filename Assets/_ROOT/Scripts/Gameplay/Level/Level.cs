namespace SnakeRunner.Gameplay.Level
{
    using Infrastructure.ServiceLocator;
    using UI;
    using Unit.Death;
    using UnityEngine;

    public class Level : MonoBehaviour
    {
        public TrailsContainer Trails;

        public UnitDeath Unit;

        private IUIBuilder uiBuilder;

        private void Start()
        {
            uiBuilder = AllServices.Container.Single<IUIBuilder>();
            
            Unit.OnDeath += FailLevel;
        }

        private void FailLevel()
        {
            uiBuilder.CreateWindow<LevelFailedWindow>();
        }

        private void OnDestroy()
        {
            Unit.OnDeath -= FailLevel;
        }
    }
}