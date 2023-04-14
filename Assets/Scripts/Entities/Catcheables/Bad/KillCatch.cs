using Entities.Characters;
using UnityEngine;

namespace Entities.Catcheables.Bad
{
    public class KillCatch : MonoBehaviour, ICatcheable
    {
        public void Catch(ICatchHandler catchHandler)
        {
            catchHandler.Die();
        }
    }
}