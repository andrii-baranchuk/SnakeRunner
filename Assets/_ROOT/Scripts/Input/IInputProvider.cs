namespace Input
{
    using System;
    using Infrastructure.ServiceLocator;
    using UnityEngine;

    public interface IInputProvider : IService
    {
        event Action<Vector2> OnTap;
        event Action<Vector2> OnPointerDown;
        event Action<Vector2> OnPointerMove;
        event Action<Vector2> OnPointerUp;
        event Action<Drag> OnDrag;
        event Action<Drag> OnDragEnd;
        event Action<Swipe> OnSwipe;
        Vector2 PointerPosition { get; }
        void Enable();
        void Disable();
        event Action<Drag> OnDragStart;
    }
}