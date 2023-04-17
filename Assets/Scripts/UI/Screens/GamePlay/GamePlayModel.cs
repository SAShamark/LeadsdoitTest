using System;
using System.Collections;
using Services;
using Services.Sequence;
using UnityEngine;

namespace UI.Screens.GamePlay
{
    public class GamePlayModel
    {
        private float _time;
        private readonly IGameplaySequence _gameplaySequence;

        public event Action<string> OnLessTime;
        public event Action OnTimeOut;
        public event Action OnStartGame;


        public GamePlayModel(IGameplaySequence gameplaySequence)
        {
            _gameplaySequence = gameplaySequence;
        }

        public IEnumerator LessTimeCoroutine(float startTime)
        {
            _time = startTime;
            _gameplaySequence.StopGame();
            while (_time > 0)
            {
                OnLessTime?.Invoke(_time.ToString());
                yield return new WaitForSecondsRealtime(Consts.Seconds);
                _time -= Consts.Seconds;
            }

            OnTimeOut?.Invoke();
            yield return new WaitForSecondsRealtime(Consts.Seconds);
            OnStartGame?.Invoke();
            _gameplaySequence.StartGame();
        }
    }
}