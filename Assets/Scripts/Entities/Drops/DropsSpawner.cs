using System.Collections;
using Entities.Point;
using UnityEngine;
using Zenject;

namespace Entities.Drops
{
    public class DropsSpawner : MonoBehaviour
    {
        [SerializeField] private float _leftXOffset = 0.2f;

        [SerializeField] private float _rightXOffset = -0.2f;

        [SerializeField] private float _yOffset = 2f;
        [SerializeField] private float _timeBeforeFirstSpawn;
        [SerializeField] private float _defaultDuration;
        [SerializeField] private bool _isSpawnDown;

        [SerializeField] private string _key;

        private Services.Factories.IFactoryProvider<Drop> _factoryProvider;
        private IFactory<Drop> _factory;
        private IPointsProvider _pointsProvider;
        private Coroutine _spawnCoroutine;

        [Inject]
        private void Construct(Services.Factories.IFactoryProvider<Drop> factoryProvider,
            IPointsProvider pointsProvider)
        {
            _factoryProvider = factoryProvider;
            _factory = _factoryProvider.Provide(_key);
            _pointsProvider = pointsProvider;
        }

        private void Start()
        {
            StartSpawning();
        }

        public void OnDestroy()
        {
            if (_spawnCoroutine != null)
            {
                StopCoroutine(_spawnCoroutine);
                _spawnCoroutine = null;
            }
        }

        private void StartSpawning()
        {
            _spawnCoroutine = StartCoroutine(LoopSpawning());
        }

        private IEnumerator LoopSpawning()
        {
            yield return new WaitForSeconds(_timeBeforeFirstSpawn);
            while (true)
            {
                yield return new WaitForSeconds(_defaultDuration);
                Spawn();
            }
        }

        private void Spawn()
        {
            Drop drop = _factory.Create();
            drop.transform.position = GetStartPosition();
        }

        private Vector2 GetStartPosition()
        {
            float yPosition =
                _isSpawnDown ? _pointsProvider.EndPoint.position.y : _pointsProvider.StartPoint.position.y;

            var startPosition = new Vector2(Random.Range(_pointsProvider.LeftPoint.position.x + _leftXOffset,
                _pointsProvider.RightPoint.position.x + _rightXOffset), yPosition + +_yOffset);
            return startPosition;
        }
    }
}