using System;

namespace Services.Money
{
    public class CoinsBank : IBank
    {
        public event Action<int> OnCurrencyChanged;
        public int Currency { get; private set; }

        public CoinsBank()
        {
            SetCurrency(0);
        }

        public void SetCurrency(int value)
        {
            Currency = value;
            OnCurrencyChanged?.Invoke(Currency);
        }

        public void EarnCurrency(int value)
        {
            Currency += value;
            OnCurrencyChanged?.Invoke(Currency);
        }

        public void SpendCurrency(int value)
        {
            Currency -= value;
            OnCurrencyChanged?.Invoke(Currency);
        }
    }
}