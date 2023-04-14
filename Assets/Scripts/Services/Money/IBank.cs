using System;

namespace Services.Money
{
    public interface IBank
    {
        event Action<int> OnCurrencyChanged;
        int Currency { get; }
        void SetCurrency(int value);
        void EarnCurrency(int value);
        void SpendCurrency(int value);
    }
}