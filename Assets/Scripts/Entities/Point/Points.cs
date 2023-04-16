using Entities.Characters;
using UnityEngine;
using Zenject;

namespace Entities.Point
{
    public class Points : MonoBehaviour, IPointsProvider
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;
        [SerializeField] private Transform _leftPoint;
        [SerializeField] private Transform _rightPoint;

        private Transform _target;

        public Transform StartPoint => _startPoint;
        public Transform EndPoint => _endPoint;
        public Transform LeftPoint => _leftPoint;
        public Transform RightPoint => _rightPoint;

        [Inject]
        private void Construct(Character character)
        {
            _target = character.transform;
        }

        private void Update()
        {
            MoveToTargetY();
        }

        private void MoveToTargetY()
        {
            transform.position = new Vector2(transform.position.x, _target.position.y);
        }
    }
}