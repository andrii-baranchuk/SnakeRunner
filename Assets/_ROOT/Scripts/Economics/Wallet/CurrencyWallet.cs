namespace Economics.Wallet
{
    using System;
    using Infrastructure.ServiceLocator;
    using Utils;

    public interface ICurrencyWallet<T> : IService where T : ICurrency
    {
        int Balance { get; }
        event Action BalanceChanged;
        void Put(int value);
        void Take(int value);
        void Set(int value);
    }

    public class CurrencyWallet<T> : ICurrencyWallet<T> where T : ICurrency
    {
        public int Balance
        {
            get => balance.Value;
            private set
            {
                balance.Value = value;
                BalanceChanged?.Invoke();
            }
        }
        
        public event Action BalanceChanged;

        private readonly PlayerPrefsStoredValue<int> balance;

        public CurrencyWallet()
        {
            balance = new(nameof(T), 0);
        }
        
        public void Put(int value)
        {
            if (value > 0)
            {
                Balance += value;
            }
        }

        public void Take(int value)
        {
            if (value > 0 && value <= Balance)
            {
                Balance -= value;
            }
        }

        public void Set(int value)
        {
            Balance = value;
        }
    }
}