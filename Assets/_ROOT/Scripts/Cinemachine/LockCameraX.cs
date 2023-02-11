namespace Cinemachine
{
    using UnityEngine;
    using UnityEngine.Serialization;

    [ExecuteInEditMode] [SaveDuringPlay] [AddComponentMenu("")] // Hide in menu
    public class LockCameraX : CinemachineExtension
    {
        [FormerlySerializedAs("m_ZPosition")]
        [Tooltip("Lock the camera's Z position to this value")]
        public float m_XPosition;
 
        protected override void PostPipelineStageCallback(
            CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (stage == CinemachineCore.Stage.Body)
            {
                var pos = state.RawPosition;
                pos.x = m_XPosition;
                state.RawPosition = pos;
            }
        }
    }
}