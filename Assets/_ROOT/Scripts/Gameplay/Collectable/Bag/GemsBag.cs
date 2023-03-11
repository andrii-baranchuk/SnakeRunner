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

        public override void Put(Collectable collectable)
        {
            wallet.Put(collectable.Count);
        }
    }
}