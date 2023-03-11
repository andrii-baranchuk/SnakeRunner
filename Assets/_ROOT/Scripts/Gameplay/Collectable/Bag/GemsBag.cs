namespace SnakeRunner.Gameplay.Collectable
{
    using Economics;
    using Economics.Wallet;
    using Infrastructure.ServiceLocator;

    public class GemsBag : CollectableBag<GemsCollectable>
    {
        private ICurrencyWallet<GemsCurrency> wallet;
        protected override void Awake()
        {
            base.Awake();
            wallet = AllServices.Container.Single<ICurrencyWallet<GemsCurrency>>();
        }

        protected override void Put(GemsCollectable collectable)
        {
            wallet.Put(collectable.Count);
        }
    }
}