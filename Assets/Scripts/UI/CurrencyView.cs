using Services.Money;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private string _format = "{0}";
        
        private IBank _bank;

        [Inject]
        private void Construct(IBank bank)
        {
            _bank = bank;
        }

        private void Start()
        {
            _bank.OnCurrencyChanged += SetCurrencyText;
            SetCurrencyText(_bank.Currency);
        }

        private void OnDestroy()
        {
            _bank.OnCurrencyChanged -= SetCurrencyText;
        }

        private void SetCurrencyText(int value)
        {
            _text.text = string.Format(_format, value);
        }
    }
}