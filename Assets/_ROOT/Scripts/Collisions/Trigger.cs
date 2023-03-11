namespace Collisions
{
    using System;
    using UnityEngine;

    public abstract class Trigger<T> : MonoBehaviour
    {
        public event Action<T> OnEnter;
        //public event Action<T> OnStay; 
        public event Action<T> OnExit;

        protected virtual void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out T component))
                OnEnter?.Invoke(component);
        }

        // protected virtual void OnTriggerStay(Collider other)
        // {
        //     if(other.TryGetComponent(out T component))
        //         OnStay?.Invoke(component);
        // }

        protected virtual void OnTriggerExit(Collider other)
        {
            if(other.TryGetComponent(out T component))
                OnExit?.Invoke(component);
        }
    }
}