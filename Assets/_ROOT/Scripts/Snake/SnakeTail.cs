namespace SnakeRunner.Gameplay.Snake
{
    using UnityEngine;

    public class SnakeTail : MonoBehaviour
    {
        [SerializeField]
        private float movementSpeed;

        [SerializeField]
        private Transform target;

        private Vector3 lastPosition;
        
        private bool targetIsMoving;

        private void Start()
        {
            lastPosition = target.position;
        }

        private void FixedUpdate()
        {
            CheckIfTargetIsMoving();
            
            if(targetIsMoving)
            {
                var direction = target.position - transform.position;
                transform.Translate(direction * (movementSpeed * Time.fixedDeltaTime));
                transform.LookAt(target);
            }
        }
        
        private void CheckIfTargetIsMoving()
        {
            var position = target.position;

            targetIsMoving = (position - lastPosition).sqrMagnitude >= float.Epsilon;

            lastPosition = position;
        }
    }
}