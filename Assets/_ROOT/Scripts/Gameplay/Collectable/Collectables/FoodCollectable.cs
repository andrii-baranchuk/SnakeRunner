namespace SnakeRunner.Gameplay.Collectable
{
    using Color;
    using UnityEngine;

    [RequireComponent(typeof(Colorable))]
    public class FoodCollectable : Collectable
    {
        [field: SerializeField]
        public Colorable Colorable { get; private set; }

        protected override void OnValidate()
        {
            base.OnValidate();
            Colorable = GetComponent<Colorable>();
        }
    }
}