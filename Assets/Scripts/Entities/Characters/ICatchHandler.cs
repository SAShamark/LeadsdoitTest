using UnityEngine;

namespace Entities.Characters
{
    public interface ICatchHandler
    {
        void EarnCoin(int value);
        void Slowdown(float percent);
        void Nitro(float percent);
        void Shield(int value);
        void Magnet(float seconds, float radius);
        void Damage(int value);
        void Heal(int value);
        void Die();
    }
}