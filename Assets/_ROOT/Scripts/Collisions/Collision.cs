﻿namespace Collisions
{
    using System;
    using UnityEngine;

    public abstract class Collision<T> : MonoBehaviour
    {
        public event Action<T> OnEnter;
        //public event Action<T> OnStay; 
        public event Action<T> OnExit;

        protected virtual void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.TryGetComponent(out T component))
                OnEnter?.Invoke(component);
        }

        // protected virtual void OnCollisionStay(Collision other)
        // {
        //     if(other.gameObject.TryGetComponent(out T component))
        //         OnStay?.Invoke(component);
        // }

        protected virtual void OnCollisionExit(Collision other)
        {
            if(other.gameObject.TryGetComponent(out T component))
                OnExit?.Invoke(component);
        }
    }
}