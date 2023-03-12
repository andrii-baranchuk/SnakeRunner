namespace UI
{
    using UnityEngine;

    public abstract class Window : MonoBehaviour
    {
        protected virtual void OnValidate()
        {
            gameObject.name = GetType().Name;
        }

        public void Close()
        {
            Destroy(gameObject);
        }
    }
}