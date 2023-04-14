using System.Collections;
using Services.Input;
using Services.Money;
using UnityEngine;
using Zenject;

namespace Entities.Characters
{
    public class Character : MonoBehaviour, ICatchHandler
    {
        [SerializeField] private CharacterData _characterData;
        [SerializeField] private Magnet _magnet;

        private IInputService _inputService;
        private IBank _bank;
        private Rigidbody2D _rigidbody;
        private CharacterStatsController _characterStatsController;

        [Inject]
        private void Construct(IInputService inputService, IBank bank)
        {
            _inputService = inputService;
            _bank = bank;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _characterStatsController = new CharacterStatsController(_characterData.CharacterStats);
        }

        private void Update()
        {
            if (_inputService.IsMove())
            {
                _characterStatsController.MoveAccelerate();
            }

            if (_inputService.IsStop() && _characterStatsController.CurrentMoveSpeed > 0)
            {
                _characterStatsController.MoveDecelerate();
            }
        }

        private void FixedUpdate()
        {
            Vector3 direction = transform.up * _characterStatsController.CurrentMoveSpeed;
            Move(direction);
            Turn();
        }

        public void Damage(int value)
        {
            _characterStatsController.Damage(value);
        }

        public void Heal(int value)
        {
            _characterStatsController.Heal(value);
        }

        public void Die()
        {
            _characterStatsController.Die();
        }

        private void Move(Vector3 direction)
        {
            if (_inputService.IsMove())
            {
                _rigidbody.velocity = direction;
            }

            if (_inputService.IsStop())
            {
                _rigidbody.velocity = direction;
            }
        }

        private void Turn()
        {
            float xPosition = transform.position.x + _inputService.Axis.x * _characterData.CharacterStats.TurnSpeed;
            transform.position = new Vector2(xPosition, transform.position.y);
        }


        public void EarnCoin(int value)
        {
            _bank.EarnCurrency(value);
        }

        public void Magnet(float seconds, float radius, LayerMask layerMask)
        {
            _magnet.Init(radius);
            StartCoroutine(TemporaryMagnet(seconds));
        }

        public void Slowdown(float seconds, float percent)
        {
            StartCoroutine(_characterStatsController.TemporarySpeedSlowdown(seconds, percent));
        }

        public void Nitro(float seconds, float percent)
        {
            StartCoroutine(_characterStatsController.TemporaryNitro(seconds, percent));
        }

        public void Shield(int value)
        {
            _characterStatsController.Shield(value);
        }

        private IEnumerator TemporaryMagnet(float seconds)
        {
            _magnet.OnMagnet();
            yield return new WaitForSeconds(seconds);
            _magnet.OffMagnet();
        }
    }
}