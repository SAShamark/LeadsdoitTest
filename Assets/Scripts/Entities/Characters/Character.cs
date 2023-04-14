using Services.Input;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Entities.Characters
{
    public class Character : MonoBehaviour, ICatchHandler
    {
        [SerializeField] private float _maxSpeed = 10f;
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _acceleration = 5f;
        [SerializeField] private float _deceleration = 10f;
        [SerializeField] private float _turnSpeed = 0.2f;
        [SerializeField] private float _currentMoveSpeed;
        [SerializeField] private int _startHealth;

        private IInputService _inputService;
        private Rigidbody2D _rigidbody;

        private int _currentHealth;
        private int _maxHealth;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _maxHealth = _startHealth;
        }

        private void Update()
        {
            if (_inputService.IsMove())
            {
                MoveAccelerate();
            }

            if (_inputService.IsStop() && _currentMoveSpeed > 0)
            {
                MoveDecelerate();
            }
        }

        private void FixedUpdate()
        {
            _currentMoveSpeed = Mathf.Max(_currentMoveSpeed, 0f);
            Vector3 direction = transform.up * _currentMoveSpeed;

            Move(direction);
            Turn();
        }

        public void Damage(int value)
        {
            if (_currentHealth > 0)
            {
                _currentHealth -= value;
            }

            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        public void Heal(int value)
        {
            _currentHealth = Mathf.Clamp(value, 0, _maxHealth);
        }

        public void Die()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
            float xPosition = transform.position.x + _inputService.Axis.x * _turnSpeed;
            transform.position = new Vector2(xPosition, transform.position.y);
        }

        private void MoveAccelerate()
        {
            if (_currentMoveSpeed < _maxSpeed)
            {
                _currentMoveSpeed += _acceleration * Time.deltaTime;
            }
        }

        private void MoveDecelerate()
        {
            if (_currentMoveSpeed > _minSpeed)
            {
                _currentMoveSpeed -= _deceleration * Time.deltaTime;
            }
        }
    }
}