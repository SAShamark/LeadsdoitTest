using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BarControl : MonoBehaviour
    {
        [SerializeField] private Image _fieldImage;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Sprite _fieldSprite;
        [SerializeField] private AbilityType _name;
        private const float StartValue = 1;

        private void Start()
        {
            _fieldImage.sprite = _fieldSprite;
            _text.text = _name.ToString();
            ChangeFieldAmount(StartValue);
        }

        private void ChangeFieldAmount(float fillProgress)
        {
            _fieldImage.fillAmount = fillProgress / StartValue;
        }
    }

    public enum AbilityType
    {
        None = 0,
        Health = 1,
        Shield = 2,
        Magnet = 3,
        Nitro = 4,
    }
}