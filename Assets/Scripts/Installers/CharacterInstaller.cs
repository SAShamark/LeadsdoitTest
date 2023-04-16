using Entities.Characters;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField] private Character _character;
        [SerializeField] private CharacterData _characterData;
        [SerializeField] private Transform _container;

        public override void InstallBindings()
        {
            Character();
        }

        private void Character()
        {
            var character = Container.InstantiatePrefabForComponent<Character>(_character, _container);
            character.Initialize(_characterData);
            Container.Bind(typeof(Character)).FromInstance(character).AsSingle();
        }
    }
}