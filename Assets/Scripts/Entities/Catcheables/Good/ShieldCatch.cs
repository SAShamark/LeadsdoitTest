using Entities.Characters;
using UnityEngine;

namespace Entities.Catcheables.Good
{
    public class ShieldCatch : MonoBehaviour, ICatcheable
    {
        [SerializeField] private int _value;

        public void Catch(ICatchHandler catchHandler)
        {
            catchHandler.Shield(_value);
        }
    }
}