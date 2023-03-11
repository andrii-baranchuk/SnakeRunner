namespace SnakeRunner.Gameplay.Collectable
{
    using System;
    using UnityEngine;

    public abstract class Collectable : MonoBehaviour
    {
        public int Count => CalculateCount();
        public Type Type { get; private set; }

        [SerializeField]
        private int defaultCount = 1;

        protected virtual void Awake() => Initialize();

        private void Initialize()
        {
            Type = GetType();
        }

        public void Collect()
        {
            gameObject.SetActive(false);
        }

        protected virtual int CalculateCount()
        {
            return defaultCount;
        }
    }
}