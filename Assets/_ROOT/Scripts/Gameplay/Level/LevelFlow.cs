namespace SnakeRunner.Gameplay.Level
{
    using Camera;
    using Infrastructure.ServiceLocator;
    using UI;
    using UnityEngine;

    public class LevelFlow : MonoBehaviour
    {
        [SerializeField]
        private Level level;

        [SerializeField]
        private Level levelPrefab;
        
        private IUIBuilder uiBuilder;
        private CameraService cameraService;

        private void Start()
        {
            uiBuilder = AllServices.Container.Single<IUIBuilder>();
            cameraService = AllServices.Container.Single<CameraService>();
            Restart();
        }

        private void CreateLevelFailedWindow()
        {
            var window = uiBuilder.CreateWindow<LevelFailedWindow>();
            window.RestartButton.onClick.AddListener(Restart);
            window.RestartButton.onClick.AddListener(window.Close);
        }
        
        private void Restart()
        {
            CleanUp();
            CreateLevel();
        }

        private void CreateLevel()
        {
            level = Instantiate(levelPrefab, transform);
            Setup(level);
        }

        private void Setup(Level level)
        {
            cameraService.LootAt(level.Unit.transform);
            level.Failed += CreateLevelFailedWindow;
        }

        private void CleanUp()
        {
            if (level != null)
            {
                level.Failed -= CreateLevelFailedWindow;
                level.gameObject.SetActive(false);
                Destroy(level.gameObject);
            }
        }
    }
}