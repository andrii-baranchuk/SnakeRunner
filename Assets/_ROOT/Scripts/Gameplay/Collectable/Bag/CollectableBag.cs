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

        public override void Put(Collectable collectable) => Put(collectable as T);

        protected abstract void Put(T collectable);
    }

    public abstract class CollectableBag : MonoBehaviour
    {
        public Type Type { get; protected set; }
        public abstract void Put(Collectable collectable);
    }
}