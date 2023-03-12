namespace UI
{
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    [RequireComponent(typeof(Button))]
    public class RestartButton : MonoBehaviour
    {
        [SerializeField]
        private Button button;

        private void OnValidate()
        {
            button = GetComponent<Button>();
        }

        private void Awake()
        {
            button.onClick.AddListener(Restart);
        }

        private void Restart()
        {
            SceneManager.LoadScene(0);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(Restart);
        }
    }
}