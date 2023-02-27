namespace SnakeRunner.Gameplay.Color
{
    using UnityEngine;

    [RequireComponent(typeof(MeshRenderer))]
    public class ColorChangerView : MonoBehaviour
    {
        [SerializeField]
        private ColorChanger colorChanger;

        [SerializeField]
        private MeshRenderer meshRenderer;

        private void OnValidate()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Start() => UpdateView();

        private void UpdateView()
        {
            var color = colorChanger.Color.Color;
            color.a = 0.5f;
            meshRenderer.material.color = color;
        }
    }
}