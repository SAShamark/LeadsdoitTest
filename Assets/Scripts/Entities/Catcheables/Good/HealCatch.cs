using Entities.Characters;
using UnityEngine;

namespace Entities.Catcheables.Good
{
    public class HealCatch : MonoBehaviour, ICatcheable
    {
        [SerializeField] private int _health;

        public void Catch(ICatchHandler catchHandler)
        {
            catchHandler.Heal(_health);
        }
    }
}