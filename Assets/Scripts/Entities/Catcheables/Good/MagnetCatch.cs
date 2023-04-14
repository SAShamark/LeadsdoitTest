using Entities.Characters;
using UnityEngine;

namespace Entities.Catcheables.Good
{
    public class MagnetCatch : MonoBehaviour, ICatcheable
    {
        [SerializeField] private float _seconds;
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layerMask;

        public void Catch(ICatchHandler catchHandler)
        {
            catchHandler.Magnet(_seconds, _radius, _layerMask);
        }
    }
}