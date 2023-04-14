using Entities.Characters;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField] private Character _character;

        public override void InstallBindings()
        {
            Character();
        }

        private void Character()
        {
            Container.Bind<Character>().FromInstance(_character).AsSingle().NonLazy();
        }
    }
}