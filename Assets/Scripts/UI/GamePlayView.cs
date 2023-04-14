using System.Collections;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GamePlayView : BaseView
    {
        [SerializeField] private GameObject _startPanel;
        [SerializeField] private GameObject _upPanel;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _readoutText;
        [SerializeField] private float _timeForStart;
        [SerializeField] private string _textAfterTime;
        private float _time;
        private GameObject _activePanel;

        private void Start()
        {
            _pauseButton.onClick.AddListener(PauseClicked);
            _time = _timeForStart;
            ShowPanel(_startPanel);
            StartCoroutine(CountdownCoroutine());
        }

        private IEnumerator CountdownCoroutine()
        {
            while (_time > 0)
            {
                ChangeReadoutText(_time.ToString());
                yield return new WaitForSeconds(Consts.Seconds);
                _time--;
            }

            _readoutText.text = _textAfterTime;
            yield return new WaitForSeconds(Consts.Seconds);
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

        private void ChangeScoreText(float value)
        {
            _scoreText.text = Mathf.Floor(value).ToString();
        }

        private void ChangeReadoutText(string value)
        {
            _readoutText.text = value;
        }
    }
}