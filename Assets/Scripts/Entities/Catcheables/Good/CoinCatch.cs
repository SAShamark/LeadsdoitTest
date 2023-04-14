using Entities.Characters;
using UnityEngine;

namespace Entities.Catcheables.Good
{
    public class CoinCatch : MonoBehaviour, ICatcheable
    {
        [SerializeField] private int _value;

        public void Catch(ICatchHandler catchHandler)
        {
            catchHandler.EarnCoin(_value);
        }
    }
}