#pragma warning disable CS0108, CS0114
namespace SnakeRunner.Gameplay.Unit
{
    using System;
    using System.Collections;
    using DG.Tweening;
    using NaughtyAttributes;
    using UnityEngine;
    
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
        
        private bool Enabled;

        private float sideMovementDelta;

        private void Start()
        {
            sideMovementDelta = transform.position.x;
        }

        private void FixedUpdate() => Move();

        private void Move()
        {
            if (Enabled)
            {
                transform.position = new Vector3
                (
                    sideMovementDelta,
                    transform.position.y, 
                    transform.position.z + forwardSpeed * Time.fixedDeltaTime
                );
            }
        }

        public void SideMovement(float targetX, Action onComplete = null)
        {
            StartCoroutine(SideMovementRoutine(targetX, onComplete));
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