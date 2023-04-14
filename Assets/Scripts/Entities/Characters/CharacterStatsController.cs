using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Entities.Characters
{
    public class CharacterStatsController
    {
        public float CurrentMoveSpeed { get; private set; }
        public int CurrentHealth { get; private set; }
        public int CurrentShield { get; private set; }

        private readonly CharacterStats _characterStats;

        public CharacterStatsController(CharacterStats characterStats)
        {
            _characterStats = characterStats;
            CurrentHealth = _characterStats.StartHealth;
        }

        public void Damage(int value)
        {
            if (CurrentShield > 0)
            {
                CurrentShield -= value;
                if (CurrentShield < 0)
                {
                    value = -CurrentShield;
                    CurrentShield = 0;
                }
                else
                {
                    value = 0;
                }
            }

            if (value > 0 && CurrentHealth > 0 && CurrentShield <= 0)
            {
                CurrentHealth -= value;
                if (CurrentHealth <= 0)
                {
                    Die();
                }
            }
        }

        public void Heal(int value)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + value, 0, _characterStats.MaxHealth);

        }

        public void Die()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Shield(int value)
        {
            CurrentShield = Mathf.Clamp(CurrentShield + value, 0, _characterStats.MaxShield);

        }

        public void MoveAccelerate()
        {
            if (CurrentMoveSpeed < _characterStats.MaxSpeed)
            {
                CurrentMoveSpeed += _characterStats.Acceleration * Time.deltaTime;
            }
        }

        public void MoveDecelerate()
        {
            if (CurrentMoveSpeed > 0)
            {
                CurrentMoveSpeed -= _characterStats.Deceleration * Time.deltaTime;
            }
        }

        public IEnumerator TemporarySpeedSlowdown(float seconds, float percent)
        {
            float startSpeed = CurrentMoveSpeed;
            CurrentMoveSpeed *= 1f - percent / _characterStats.MaxSpeed;
            yield return new WaitForSeconds(seconds);
            CurrentMoveSpeed = startSpeed;
        }

        public IEnumerator TemporaryNitro(float seconds, float percent)
        {
            float startSpeed = CurrentMoveSpeed;
            CurrentMoveSpeed *= 1f - percent / _characterStats.MaxSpeed;
            yield return new WaitForSeconds(seconds);
            CurrentMoveSpeed = startSpeed;
        }
    }
}