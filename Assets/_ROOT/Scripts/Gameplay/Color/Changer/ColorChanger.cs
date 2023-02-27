namespace SnakeRunner.Gameplay.Color
{
    using Infrastructure.ServiceLocator;
    using UnityEngine;

    public abstract class ColorChanger : MonoBehaviour
    {
        private ColorSettings settings;

        [SerializeField]
        protected ColorType ColorType;
        
        public ColorSetting Color { get; private set; }

        protected virtual void OnValidate() { }

        protected virtual void Awake() => Initialize();

        private void Initialize()
        {
            settings = AllServices.Container.Single<ColorSettings>();
            Color = settings.For(ColorType);
        }

        protected virtual void Start() {}

        protected void ChangeColor(Colorable colorable)
        {
            colorable.ChangeColor(Color);
        }

        protected virtual void OnDestroy() { }
    }
}