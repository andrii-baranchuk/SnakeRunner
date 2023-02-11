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
            
            inputProvider.OnSwipe += OnSwipe;
            inputProvider.OnTap += OnTap;
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

        private void OnTap(Vector2 position) => Enable();
        private void Enable() => unitMovement.ForwardMovement(true);
        private bool SideMovementInProgress() => targetTrail != null;

        private void OnDestroy()
        {
            inputProvider.OnSwipe -= OnSwipe;
            inputProvider.OnTap -= OnTap;
        }
    }
}