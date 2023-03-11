namespace Economics.View
{
    using Infrastructure.ServiceLocator;
    using TMPro;
    using UnityEngine;
    using Wallet;

    public abstract class CurrencyBalanceView<T> : MonoBehaviour where T : ICurrency
    {
        [SerializeField]
        private TMP_Text text;
        
        private ICurrencyWallet<T> wallet;

        private void Awake()
        {
            wallet = AllServices.Container.Single<ICurrencyWallet<T>>();
        }

        private void Start()
        {
            wallet.BalanceChanged += UpdateView;
            UpdateView();
        }

        private void UpdateView()
        {
            text.SetText(wallet.Balance.ToString());
        }

        private void OnDestroy()
        {
            wallet.BalanceChanged -= UpdateView;
        }
    }
}