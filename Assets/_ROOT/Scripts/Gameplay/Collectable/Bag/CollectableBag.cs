namespace SnakeRunner.Gameplay.Collectable
{
    using System;
    using UnityEngine;

    public abstract class CollectableBag<T> : CollectableBag where T : Collectable
    {
        protected virtual void Awake() => Initialize();

        protected virtual void Initialize()
        {
            Type = typeof(T);
        }
    }

    public abstract class CollectableBag : MonoBehaviour
    {
        public virtual Type Type { get; protected set; }

        public abstract void Put(Collectable collectable);
    }
}