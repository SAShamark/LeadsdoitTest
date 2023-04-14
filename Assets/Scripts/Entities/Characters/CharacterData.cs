using System;
using UnityEngine;

namespace Entities.Characters
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Character/Data", order = 1)]
    public class CharacterData : ScriptableObject
    {
        [SerializeField] private CharacterStats _characterStats;

        public CharacterStats CharacterStats => _characterStats;
    }

    [Serializable]
    public class CharacterStats
    {
        [SerializeField] private float _maxSpeed = 5;
        [SerializeField] private float _acceleration = 1;
        [SerializeField] private float _deceleration = 1;
        [SerializeField] private float _turnSpeed = 0.2f;
        [SerializeField] private int _startHealth = 100;
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private int _maxShield = 100;

        public float MaxSpeed => _maxSpeed;
        
        public float Acceleration => _acceleration;

        public float Deceleration => _deceleration;

        public float TurnSpeed => _turnSpeed;

        public int StartHealth => _startHealth;

        public int MaxHealth => _maxHealth;

        public int MaxShield => _maxShield;
    }
}