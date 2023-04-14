using UnityEngine;

namespace Entities.Point
{
    public class Points : MonoBehaviour, IPointsProvider
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;
        [SerializeField] private Transform _leftPoint;
        [SerializeField] private Transform _rightPoint;

        public Transform StartPoint => _startPoint;
        public Transform EndPoint => _endPoint;
        public Transform LeftPoint => _leftPoint;
        public Transform RightPoint => _rightPoint;


        private void Update()
        {
            transform.position = new Vector2(transform.position.x, _target.position.y);
        }
    }
}