#pragma warning disable CS0108, CS0114
namespace SnakeRunner.Gameplay.Unit
{
    using System;
    using System.Collections;
    using UnityEngine;
    
    public class UnitMovement : MonoBehaviour
    {
        [Header("Forward Settings")]
        [SerializeField]
        private float forwardSpeed;
        
        [Header("Horizontal Settings")]
        [SerializeField]
        private float horizontalMovementDuration;
        
        public bool Enabled { get; private set; }

        private float sideMovementDelta;

        private Quaternion targetRotation;

        private void Start()
        {
            sideMovementDelta = transform.position.x;
            targetRotation = transform.rotation;
        }

        private void FixedUpdate() => Move();

        private void Move()
        {
            if (Enabled)
            {
                var nextPosition = new Vector3
                (
                    sideMovementDelta,
                    transform.position.y, 
                    transform.position.z + forwardSpeed * Time.fixedDeltaTime
                );

                transform.rotation = targetRotation;

                transform.position = nextPosition;
            }
        }

        public void SideMovementAndRotation(float targetX, Action onComplete = null)
        {
            var direction = targetX >= transform.position.x ? 1f : -1f;
            StartCoroutine(SideMovementRoutine(targetX, onComplete));
            SideRotation(direction, 45f, horizontalMovementDuration/2,
                () => SideRotation(1,0,horizontalMovementDuration/2));
        }

        private void SideRotation(float direction, float degree, float time, Action onComplete = null)
        {
            StartCoroutine(SideRotationRoutine(direction, degree, time, onComplete));
        }

        private IEnumerator SideRotationRoutine(float direction, float degree, float time,Action onComplete = null)
        {
            var initialRotation = transform.rotation;
            var targetRotationLocal = Quaternion.Euler(new Vector3(0f, direction * degree, 0f));
            
            float timeElapsed = 0;

            while (timeElapsed < time)
            {
                var ratio = Mathf.Clamp01(timeElapsed / time);
                
                targetRotation = Quaternion.Slerp(initialRotation, targetRotationLocal, ratio);
                
                timeElapsed += Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }

            targetRotation = targetRotationLocal;
            
            onComplete?.Invoke();
        }

        private IEnumerator SideMovementRoutine(float targetX, Action onComplete = null)
        {
            float initialX = transform.position.x;
            
            float timeElapsed = 0;

            while (timeElapsed < horizontalMovementDuration)
            {
                var ratio = Mathf.Clamp01(timeElapsed / horizontalMovementDuration);
                
                sideMovementDelta = Mathf.Lerp(initialX, targetX, ratio);
                
                timeElapsed += Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }
            
            sideMovementDelta = targetX;
            
            onComplete?.Invoke();
        }

        public void Enable()
        {
            Enabled = true;
        }

        public void Disable()
        {
            Enabled = false;
        }
    }
}