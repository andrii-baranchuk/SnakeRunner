namespace SnakeRunner.Gameplay.Color
{
    using System.Collections.Generic;
    using System.Linq;
    using NaughtyAttributes;
    using UnityEngine;


    [RequireComponent(typeof(BoxCollider))]
    public class Colorable : MonoBehaviour
    {
        [field: SerializeField]
        public ColorSetting CurrentColor { get; private set;}
        
        [SerializeField]
        private List<MeshRenderer> meshRenderers;

        private void OnValidate()
        {
            Setup();
        }

        [Button()]
        private void Setup()
        {
            var collider = GetComponent<BoxCollider>();
            collider.isTrigger = true;
            
            meshRenderers = GetComponentsInChildren<MeshRenderer>().ToList();
        }

        public void ChangeColor(ColorSetting to)
        {
            CurrentColor = to;
            
            meshRenderers.ForEach(m => m.material.color = CurrentColor.Color);
        }
    }
}