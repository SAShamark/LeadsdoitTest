using UnityEngine;

namespace Entities.Roads
{
    public class RoadMover : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Transform _road1;
        [SerializeField] private Transform _road2;
        
        private bool _isMoveRoad1;

        private const float ForwardDistance = 20;


        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (!_isMoveRoad1)
            {
                if (_target.position.y >= _road2.position.y)
                {
                    _road1.position = new Vector3(_road2.position.x, _road2.position.y + ForwardDistance);
                    _isMoveRoad1 = true;
                }
            }
            else
            {
                if (_target.position.y >= _road1.position.y)
                {
                    _road2.position = new Vector3(_road1.position.x, _road1.position.y + ForwardDistance);
                    _isMoveRoad1 = false;
                }
            }
        }
    }
}