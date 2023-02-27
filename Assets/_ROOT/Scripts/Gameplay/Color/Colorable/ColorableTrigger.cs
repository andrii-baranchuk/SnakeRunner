namespace SnakeRunner.Gameplay.Color
{
    using Collisions;
    using UnityEngine;

    [RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
    public class ColorableTrigger : Trigger<Colorable>
    {
        private void OnValidate()
        {
            var boxCollider = GetComponent<BoxCollider>();
            boxCollider.isTrigger = true;

            var rigidBody = GetComponent<Rigidbody>();
            rigidBody.useGravity = false;
        }
    }
}