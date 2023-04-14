using UnityEngine;

namespace Entities.Characters
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Magnet : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D _circleCollider2D;

        public void Init(float radius)
        {
            _circleCollider2D.radius = radius;
        }

        public void OnMagnet()
        {
            gameObject.SetActive(true);
        }

        public void OffMagnet()
        {
            gameObject.SetActive(false);
        }
    }
}