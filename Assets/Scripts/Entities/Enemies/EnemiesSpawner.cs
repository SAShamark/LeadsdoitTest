using System.Collections;
using Entities;
using Entities.Enemies;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class EnemiesSpawner : MonoBehaviour
    {
        [SerializeField] private float _leftXOffset = 0.2f;

        [SerializeField] private float _rightXOffset = -0.2f;

        [SerializeField] private float _yOffset = 2f;
        [SerializeField] private float _defaultDuration;

        [SerializeField] private string _key;

        private Services.Factories.IFactoryProvider<Enemy> _factoryProvider;
        private IFactory<Enemy> _factory;
        private IPointsProvider _pointsProvider;
        private Coroutine _spawnCoroutine;

        [Inject]
        private void Construct(Services.Factories.IFactoryProvider<Enemy> factoryProvider,
            IPointsProvider pointsProvider)
        {
            _factoryProvider = factoryProvider;
            _factory = _factoryProvider.Provide(_key);
            _pointsProvider = pointsProvider;
        }

        private void Start()
        {
            StartSpawning(_defaultDuration);
        }

        public void StartSpawning(float duration)
        {
            StopSpawning();
            _spawnCoroutine = StartCoroutine(LoopSpawning(duration));
        }

        public void StopSpawning()
        {
            if (_spawnCoroutine != null)
            {
                StopCoroutine(_spawnCoroutine);
                _spawnCoroutine = null;
            }
        }

        private IEnumerator LoopSpawning(float duration)
        {
            while (true)
            {
                yield return new WaitForSeconds(duration);
                Spawn();
            }
        }

        private void Spawn()
        {
            Enemy enemy = _factory.Create();
            enemy.transform.position = GetStartPosition();
        }

        private Vector2 GetStartPosition()
        {
            var startPosition = new Vector2(Random.Range(_pointsProvider.LeftPoint.position.x + _leftXOffset,
                    _pointsProvider.RightPoint.position.x + _rightXOffset),
                _pointsProvider.StartPoint.position.y + _yOffset);
            return startPosition;
        }
    }
}