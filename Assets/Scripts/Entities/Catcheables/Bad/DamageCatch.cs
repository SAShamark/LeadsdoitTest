using Entities.Characters;
using UnityEngine;

namespace Entities.Catcheables.Bad
{
    public class DamageCatch : MonoBehaviour, ICatcheable
    {
        [SerializeField] private int _damage;

        public void Catch(ICatchHandler catchHandler)
        {
            catchHandler.Damage(_damage);
        }
    }
}