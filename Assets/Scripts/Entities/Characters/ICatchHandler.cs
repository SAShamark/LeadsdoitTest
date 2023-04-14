namespace Entities
{
    public interface ICatchHandler
    {
        void Damage(int value);
        void Heal(int value);
        void Die();
    }
}