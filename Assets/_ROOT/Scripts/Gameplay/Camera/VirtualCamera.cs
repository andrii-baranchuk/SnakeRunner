namespace SnakeRunner.Gameplay.Camera
{
    using Cinemachine;
    using UnityEngine;

    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class VirtualCamera : MonoBehaviour
    {
        [SerializeField]
        private CinemachineVirtualCamera cm;

        private void OnValidate()
        {
            cm = GetComponent<CinemachineVirtualCamera>();
        }
        
        public void LookAt(Transform target)
        {
            cm.m_Follow = cm.m_LookAt = target;
        }

        public void ResetLook()
        {
            cm.m_Follow = cm.m_LookAt = null;
        }
    }
}