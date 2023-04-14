using Entities.Characters;
using UnityEngine;

namespace Entities.Catcheables.Good
{
    public class NitroCatch : MonoBehaviour, ICatcheable
    {
        [SerializeField] private float _seconds;
        [SerializeField] private float _percentForSpeed;

        public void Catch(ICatchHandler catchHandler)
        {
            catchHandler.Nitro(_seconds, _percentForSpeed);
        }
    }
}