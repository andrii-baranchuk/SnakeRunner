﻿namespace SnakeRunner.Gameplay.Color
{
    using System.Collections.Generic;
    using System.Linq;
    using NaughtyAttributes;
    using UnityEngine;

    public class InitialColorChanger : ColorChanger
    {
        [SerializeField]
        private List<Colorable> colorables;

        protected override void Start()
        {
            base.Start();
            colorables.ForEach(ChangeColor);
        }

        [Button()]
        private void FindColorables()
        {
            colorables = GetComponentsInChildren<Colorable>().ToList();
        }
    }
}