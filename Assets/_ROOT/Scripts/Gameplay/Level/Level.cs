namespace SnakeRunner.Gameplay.Level
{
    using System;
    using Unit.Death;
    using UnityEngine;

    public class Level : MonoBehaviour
    {
        public TrailsContainer Trails;
        public UnitDeath Unit;
        public event Action Failed;

        private void Start()
        {
            Unit.OnDeath += Fail;
        }

        private void Fail()
        {
            Failed?.Invoke();
        }

        private void OnDestroy()
        {
            Unit.OnDeath -= Fail;
        }
    }
}