namespace UI
{
    using System;
    using UnityEngine;

    public abstract class Window : MonoBehaviour
    {
        protected virtual void OnValidate()
        {
            gameObject.name = GetType().Name;
        }
    }
}