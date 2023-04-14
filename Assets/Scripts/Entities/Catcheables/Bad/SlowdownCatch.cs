using Entities.Characters;
using UnityEngine;

namespace Entities.Catcheables.Bad
{
    public class SlowdownCatch : MonoBehaviour, ICatcheable
    {
        [Range(0, 1)] [SerializeField] private float _slowdownPercent;

        public void Catch(ICatchHandler catchHandler)
        {
            catchHandler.Slowdown(_slowdownPercent);
        }
    }
}