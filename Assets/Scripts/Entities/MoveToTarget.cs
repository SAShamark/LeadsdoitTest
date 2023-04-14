using Entities.Characters;
using Services;
using UnityEngine;
using Zenject;

namespace Entities
{
    public class MoveToTarget : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        private Transform _target;

        [Inject]
        private void Construct(Character character)
        {
            _target = character.transform;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            float distance = Vector3.Distance(transform.position, _target.position);

            if (distance > Consts.DistanceThreshold)
            {
                Vector3 direction = (_target.position - transform.position).normalized;
                transform.position += direction * (_speed * Time.deltaTime);
            }
        }
    }
}