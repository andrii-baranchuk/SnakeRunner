namespace SnakeRunner.Gameplay.Unit.Death
{
    using System;
    using UnityEngine;

    public class UnitDeath : MonoBehaviour
    {
        public event Action OnDeath; 

        [SerializeField]
        private TrailSwipeMovementControl movementControl;

        [SerializeField]
        private UnitMovement movement;

        public void Kill()
        {
            movementControl.Disable();
            movement.ForwardMovement(false);
            OnDeath?.Invoke();
        }
    }
}