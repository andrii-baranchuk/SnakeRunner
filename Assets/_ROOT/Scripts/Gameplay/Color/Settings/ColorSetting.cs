namespace SnakeRunner.Gameplay.Color
{
    using System;
    using UnityEngine;

    [Serializable]
    public class ColorSetting
    {
        [field: SerializeField]
        public ColorType ColorType { get; private set; }
        [field: SerializeField]
        public Color Color { get; private set; }
    }
}