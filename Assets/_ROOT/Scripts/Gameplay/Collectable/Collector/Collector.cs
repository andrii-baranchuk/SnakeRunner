namespace SnakeRunner.Gameplay.Collectable
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    [RequireComponent(typeof(CollectableTrigger))]
    public class Collector : MonoBehaviour
    {
        [SerializeField]
        private List<CollectableBag> bags;

        private CollectableTrigger trigger;

        private void Awake()
        {
            trigger = GetComponent<CollectableTrigger>();
            trigger.OnEnter += TryCollect;
        }

        private void OnDestroy()
        {
            trigger.OnEnter -= TryCollect;
        }

        private void TryCollect(Collectable collectable)
        {
            var bag = For(collectable);

            if (bag != null)
            {
                collectable.Collect();
                bag.Put(collectable);
            }
        }

        private CollectableBag For(Collectable collectable) => 
            bags.FirstOrDefault(b => b.Type == collectable.Type);
    }
}