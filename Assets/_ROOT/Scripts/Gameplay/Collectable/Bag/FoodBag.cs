namespace SnakeRunner.Gameplay.Collectable
{
    using Color;
    using Unit.Death;
    using UnityEngine;

    public class FoodBag : CollectableBag<FoodCollectable>
    {
        [SerializeField]
        private Colorable ownerColorable;
        [SerializeField]
        private UnitDeath death;
        
        protected override void Put(FoodCollectable collectable)
        {
            if (ownerColorable.SameColorAs(collectable.Colorable))
            {
                //TODO
                //Collect
            }
            else
            {
                death.Kill();
            }
        }
    }
}