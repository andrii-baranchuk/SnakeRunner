namespace SnakeRunner.Gameplay.Color
{
    using NaughtyAttributes;
    using UnityEngine;

    [RequireComponent(typeof(ColorableTrigger))]
    public class TriggerColorChanger : ColorChanger
    {
        [SerializeField, ReadOnly]
        private ColorableTrigger trigger;
        
        protected override void OnValidate()
        {
            trigger = GetComponent<ColorableTrigger>();
        }

        protected override void Start()
        {
            base.Start();
            trigger.OnEnter += ChangeColor;
        }

        protected override void OnDestroy()
        {
            trigger.OnEnter -= ChangeColor;
        }
    }
}