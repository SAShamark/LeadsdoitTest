using UnityEngine;
using Zenject;

namespace UI.Screens.GamePlay
{
    [RequireComponent(typeof(GamePlayView))]
    public class GamePlayPresenter : MonoBehaviour
    {
        [SerializeField] private GameObject _startPanel;
        [SerializeField] private GameObject _upPanel;
        [SerializeField] private float _timeForStart;
        [SerializeField] private string _textAfterTimer;

        private GamePlayView _gamePlayView;
        private GamePlayModel _gamePlayModel;

        [Inject]
        private void Construct(GamePlayModel gamePlayModel)
        {
            _gamePlayModel = gamePlayModel;
        }

        private void Awake()
        {
            _gamePlayView = GetComponent<GamePlayView>();
        }

        private void Start()
        {
            _gamePlayModel.OnLessTime += _gamePlayView.ChangeReadoutText;
            _gamePlayModel.OnTimeOut += TimeOut;
            _gamePlayModel.OnStartGame += StartGame;

            _gamePlayView.ShowPanel(_startPanel);
            StartCoroutine(_gamePlayModel.LessTimeCoroutine(_timeForStart));
        }

        private void OnDestroy()
        {
            _gamePlayModel.OnLessTime -= _gamePlayView.ChangeReadoutText;
            _gamePlayModel.OnTimeOut -= TimeOut;
            _gamePlayModel.OnStartGame -= StartGame;
        }

        private void TimeOut()
        {
            _gamePlayView.ChangeReadoutText(_textAfterTimer);
        }

        private void StartGame()
        {
            _gamePlayView.ShowPanel(_upPanel);
        }
    }
}