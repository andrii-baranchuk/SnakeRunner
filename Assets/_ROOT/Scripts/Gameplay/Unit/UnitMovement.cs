namespace SnakeRunner.Gameplay.Unit
{
    using UnityEngine;

    [RequireComponent(typeof(CharacterController))]
    public class UnitMovement : MonoBehaviour
    {
        public float Speed;
        
        [SerializeField]
        private bool disableGravity;
        
        [SerializeField] 
        private float smoothness = 0.1f;

        private CharacterController characterController;
        
        private Vector3 direction = Vector3.zero;

        private Vector3 targetVelocity;
        private Vector3 smoothedVelocity;
        private Vector3 currentVelocity;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        public void SetMovementDirection(Vector3 direction)
        {
            this.direction = direction;
        }

        private void Update() => Move();

        private void Move()
        {
            targetVelocity = Vector3.zero;
            
            if (direction.sqrMagnitude > Constants.Epsilon)
            {
                targetVelocity = direction * Speed;
            }

            var gravity = disableGravity? Physics.gravity : Vector3.zero;
            
            smoothedVelocity =
                Vector3.SmoothDamp(smoothedVelocity, targetVelocity + gravity, ref currentVelocity,
                    smoothness);
            characterController.Move(smoothedVelocity * Time.deltaTime);
        }
    }
}