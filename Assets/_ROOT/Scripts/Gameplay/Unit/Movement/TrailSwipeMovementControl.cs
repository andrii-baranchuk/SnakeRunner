namespace SnakeRunner.Gameplay.Unit
{
    using DG.Tweening;
    using Infrastructure.ServiceLocator;
    using Input;
    using Level;
    using NaughtyAttributes;
    using UnityEngine;

    [RequireComponent(typeof(UnitMovement))]
    public class TrailSwipeMovementControl : MonoBehaviour
    {
        public bool Enabled { get; private set; }
        
        [Header("Trails Info")]
        [SerializeField, ReadOnly]
        private Trail currentTrail;

        [SerializeField, ReadOnly]
        private Trail targetTrail;
        
        [Header("References")]
        [SerializeField]
        private TrailsContainer trails;
        
        [SerializeField]
        private UnitMovement unitMovement;

        private IInputProvider inputProvider;

        private void OnValidate() => FindReferences();
        private void FindReferences() => unitMovement ??= GetComponent<UnitMovement>();

        private void Awake()
        {
            FindReferences();
            inputProvider = AllServices.Container.Single<IInputProvider>();
        }

        private void Start()
        {
            currentTrail = trails.InitialTrail();
            Enable();
        }

        public void Enable()
        {
            inputProvider.OnSwipe += OnSwipe;
            inputProvider.OnTap += OnTap;
            Enabled = true;
        }

        public void Disable()
        {
            inputProvider.OnSwipe -= OnSwipe;
            inputProvider.OnTap -= OnTap;
            Enabled = false;
        }
        

        private void OnSwipe(Swipe swipe)
        {
            if(SideMovementInProgress()) return;

            var potentialTrail = ChooseTrail(swipe);

            if (potentialTrail != null)
            {
                OrderToMove(to: potentialTrail);
            }
        }

        private void OrderToMove(Trail to)
        {
            targetTrail = to;
            unitMovement
                .SideMovement(targetTrail.transform.position.x)
                .OnComplete(() =>
                {
                    currentTrail = targetTrail;
                    targetTrail = null;
                });
        }

        private Trail ChooseTrail(Swipe swipe)
        {
            Trail potentialTrail = swipe.Direction switch
            {
                SwipeDirection.Right => trails.ToTheRightFrom(currentTrail),
                SwipeDirection.Left => trails.ToTheLeftFrom(currentTrail),
                _ => null
            };

            return potentialTrail;
        }

        private void OnTap(Vector2 position) => unitMovement.ForwardMovement(true);
        private bool SideMovementInProgress() => targetTrail != null;

        private void OnDestroy()
        {
            Disable();
        }
    }
}