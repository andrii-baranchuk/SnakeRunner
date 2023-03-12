namespace SnakeRunner.Gameplay.Camera
{
    using Infrastructure.ServiceLocator;
    using UnityEngine;

    public class CameraService : MonoBehaviour, IService
    {
        [SerializeField]
        private VirtualCamera camera;

        public void LootAt(Transform target) => camera.LookAt(target);
    }
}