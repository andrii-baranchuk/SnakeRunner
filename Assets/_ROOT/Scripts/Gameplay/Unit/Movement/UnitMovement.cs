#pragma warning disable CS0108, CS0114
namespace SnakeRunner.Gameplay.Unit
{
    using DG.Tweening;
    using NaughtyAttributes;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody))]
    public class UnitMovement : MonoBehaviour
    {
        [Header("Forward Settings")]
        [SerializeField]
        private float forwardSpeed;
        
        [Header("Horizontal Settings")]
        [SerializeField, Label("Movement Duration")]
        private float horizontalMovementDuration;
        [SerializeField, Label("Movement Ease")]
        private Ease horizontalMovementEase;
        
        private bool forwardMovementEnabled;
        private Rigidbody rigidbody;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate() => Move();

        public void ForwardMovement(bool enable)
        {
            forwardMovementEnabled = enable;
        }

        public Tweener SideMovement(float targetX)
        {
            return DOVirtual
                .Float(transform.position.x, targetX, horizontalMovementDuration, SetTargetX)
                .SetUpdate(UpdateType.Fixed)
                .SetEase(horizontalMovementEase);
        }

        private void SetTargetX(float targetX)
        {
            var newPosition = rigidbody.position;
            newPosition.x = targetX;

            rigidbody.MovePosition(newPosition);
        }

        private void Move()
        {
            ForwardMovement();
        }

        private void ForwardMovement()
        {
            if (forwardMovementEnabled)
            {
                rigidbody.MovePosition(transform.position + Vector3.forward * (forwardSpeed * Time.fixedDeltaTime));
            }
        }
    }
}