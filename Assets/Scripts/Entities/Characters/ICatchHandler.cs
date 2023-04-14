using UnityEngine;

namespace Entities.Characters
{
    public interface ICatchHandler
    {
        void EarnCoin(int value);
        void Slowdown(float seconds, float percent);
        void Nitro(float seconds, float percent);
        void Shield(int value);
        void Magnet(float seconds, float radius, LayerMask layerMask);
        void Damage(int value);
        void Heal(int value);
        void Die();
    }
}