namespace SnakeRunner.Gameplay.Color
{
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure.ServiceLocator;
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(ColorSettings), menuName = "Gameplay/Settings/Color", order = 0)]
    public class ColorSettings : ScriptableObject, IService
    {
        [field: SerializeField]
        public List<ColorSetting> Colors { get; private set; }

        public ColorSetting For(ColorType type)
        {
            return Colors.FirstOrDefault(c => c.ColorType == type);
        }
        
        private static readonly string Path = $"Gameplay/{nameof(ColorSettings)}";

        public static ColorSettings Load() => 
            Resources.Load<ColorSettings>(Path);
    }
}