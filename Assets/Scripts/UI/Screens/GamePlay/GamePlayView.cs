using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.GamePlay
{
    public class GamePlayView : BaseView
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private TMP_Text _readoutText;

        private GameObject _activePanel;


        private void Start()
        {
            _pauseButton.onClick.AddListener(PauseClicked);
        }

        private void PauseClicked()
        {
        }

        public void ShowPanel(GameObject nextPanel)
        {
            _activePanel?.SetActive(false);
            nextPanel.SetActive(true);
            _activePanel = nextPanel;
        }

        public void ChangeReadoutText(string value)
        {
            _readoutText.text = value;
        }
    }
}