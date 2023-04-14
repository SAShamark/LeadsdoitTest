using System.Collections;
using Services;
using Services.Sequence;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Screens
{
    public class GamePlayView : BaseView
    {
        [SerializeField] private GameObject _startPanel;
        [SerializeField] private GameObject _upPanel;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private TMP_Text _readoutText;

        [SerializeField] private float _timeForStart;
        [SerializeField] private string _textAfterTime;
        private IGameplaySequence _gameplaySequence;
        private GameObject _activePanel;
        private float _time;

        [Inject]
        private void Construct(IGameplaySequence gameplaySequence)
        {
            _gameplaySequence = gameplaySequence;
        }

        private void Start()
        {
            _pauseButton.onClick.AddListener(PauseClicked);
            _time = _timeForStart;
            ShowPanel(_startPanel);
            StartCoroutine(CountdownCoroutine());
        }

        private IEnumerator CountdownCoroutine()
        {
            _gameplaySequence.StopGame();
            while (_time > 0)
            {
                ChangeReadoutText(_time.ToString());
                yield return new WaitForSecondsRealtime(Consts.Seconds);
                _time--;
            }

            _readoutText.text = _textAfterTime;
            yield return new WaitForSecondsRealtime(Consts.Seconds);
            _gameplaySequence.StartGame();
            ShowPanel(_upPanel);
        }


        private void ShowPanel(GameObject nextPanel)
        {
            _activePanel?.SetActive(false);
            nextPanel.SetActive(true);
            _activePanel = nextPanel;
        }

        private void PauseClicked()
        {
        }

        private void ChangeReadoutText(string value)
        {
            _readoutText.text = value;
        }
    }
}