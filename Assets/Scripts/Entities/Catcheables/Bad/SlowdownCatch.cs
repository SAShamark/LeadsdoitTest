using Entities.Characters;
using UnityEngine;

namespace Entities.Catcheables.Bad
{
    public class SlowdownCatch : MonoBehaviour, ICatcheable
    {
        [SerializeField] private float _seconds;
        [SerializeField] private float _slowdownPercent;

        public void Catch(ICatchHandler catchHandler)
        {
            catchHandler.Slowdown(_seconds, _slowdownPercent);
        }
    }
}