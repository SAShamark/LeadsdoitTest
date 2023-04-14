using Entities.Characters;
using UnityEngine;

namespace Entities.Catcheables.Good
{
    public class NitroCatch : MonoBehaviour, ICatcheable
    {
        [Range(0, 1)] [SerializeField] private float _percentForSpeed;

        public void Catch(ICatchHandler catchHandler)
        {
            catchHandler.Nitro(_percentForSpeed);
        }
    }
}